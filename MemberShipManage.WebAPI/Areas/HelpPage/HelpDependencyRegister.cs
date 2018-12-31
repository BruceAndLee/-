using Autofac;
using MemberShipManage.Framework.DependencyManage;
using System;
using System.Reflection;
using System.Web.Http.Description;

namespace MemberShipManage.WebAPI.Areas.HelpPage
{
    public class HelpDependencyRegister : IDependencyRegister
    {
        public virtual void Register(ContainerBuilder builder)
        {
            builder.RegisterType<XmlDocumentationProvider>().As<IDocumentationProvider>()
                .WithParameter("documentPath", string.Concat(AppDomain.CurrentDomain.BaseDirectory, "/bin/", Assembly.GetExecutingAssembly()
                .GetName().Name, ".xml"))
                .InstancePerLifetimeScope();
        }

        public int Order
        {
            get { return 1; }
        }
    }
}