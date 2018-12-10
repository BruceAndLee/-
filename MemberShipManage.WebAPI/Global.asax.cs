using Autofac;
using Autofac.Integration.WebApi;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Mvc;
using MemberShipManage.Framework;
using MemberShipManage.Infrastructure;
using MemberShipManage.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MemberShipManage.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            this.InitializeIoc();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            ModelValidatorProviders.Providers.Add(new FluentValidationModelValidatorProvider(new AttributedValidatorFactory()));
            ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;
            FluentValidationModelValidatorProvider.Configure();
            AutoMapperManager.InitMapperCollection();
        }

        private void InitializeIoc()
        {
            if (Singleton<IAppStartManager>.Instance == null)
            {
                Singleton<IAppStartManager>.Instance = new AppStartManager();
            }

            Singleton<IAppStartManager>.Instance.Initialize(Assembly.GetAssembly(typeof(WebApiApplication)), RegisterAPIController, SetAPIDependencyResolver);
        }

        private void RegisterAPIController(ContainerBuilder builder, Assembly assembly)
        {
            builder.RegisterApiControllers(assembly);
        }

        private void SetAPIDependencyResolver(IContainer container)
        {
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
