using MemberShipManage.Framework;
using MemberShipManage.Infrastructure;
using MemberShipManage.Service.CustomerManage;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MemberShipManage.WebAPI.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            _publicClientId = publicClientId ?? throw new ArgumentNullException("publicClientId");
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            ICustomerService service = Singleton<IAppStartManager>.Instance.ContainerManager.Resolve<ICustomerService>();
            var customer = service.GetCustomerInfo(context.UserName, context.Password);

            if (customer != null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, "user"));

            var props = new AuthenticationProperties(new Dictionary<string, string>
            {
                {
                    "as:client_id",
                    context.ClientId ?? string.Empty
                },
                {
                    "userName",
                    context.UserName
                }
            });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);

            await base.GrantResourceOwnerCredentials(context);

            //var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            //ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);

            //if (user == null)
            //{
            //    context.SetError("invalid_grant", "用户名或密码不正确。");
            //    return;
            //}

            //ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,
            //   OAuthDefaults.AuthenticationType);
            //ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,
            //    CookieAuthenticationDefaults.AuthenticationType);

            //AuthenticationProperties properties = CreateProperties(user.UserName);
            //AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
            //context.Validated(ticket);
            //context.Request.Context.Authentication.SignIn(cookiesIdentity);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string client_id;
            string client_secret;
            context.TryGetFormCredentials(out client_id, out client_secret);
            // 资源所有者密码凭据未提供客户端 ID。
            if (client_id == GlobalConfig.AppID)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public override async Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var originalClient = context.Ticket.Properties.Dictionary["client_id"];

            var currentClient = context.ClientId;

            if (originalClient != currentClient)
            {
                context.Rejected();
                return;
            }

            var oAuthIdentity = new ClaimsIdentity(context.Ticket.Identity);

            var props = new AuthenticationProperties(new Dictionary<string, string> { { "client_id", context.ClientId } });

            oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, context.ClientId));//"newClaim", "refreshToken"

            var newTicket = new AuthenticationTicket(oAuthIdentity, context.Ticket.Properties);

            context.Validated(newTicket);

            await base.GrantRefreshToken(context);
        }

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }
}