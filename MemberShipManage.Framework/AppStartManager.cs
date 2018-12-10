using Autofac;
using Autofac.Integration.Mvc;
using MemberShipManage.Framework.DependencyManage;
using MemberShipManage.Framework.TypeFinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MemberShipManage.Framework
{
    public class AppStartManager : IAppStartManager
    {
        public AppStartManager() { }
        private ContainerManager _containerManager;
        public void Initialize(Assembly assembly, Action<ContainerBuilder, Assembly> registerAPI = null, Action<IContainer> setDependencyResolver = null)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(assembly);
            registerAPI?.Invoke(builder, assembly);

            builder.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces();
            RegisterAll(builder);

            var container = builder.Build();
            _containerManager = new ContainerManager(container);
            //set dependency resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            setDependencyResolver?.Invoke(container);
        }

        private void RegisterAll(ContainerBuilder builder)
        {
            var typeFinder = new WebAppTypeFinder();
            builder.RegisterInstance(this).As<IAppStartManager>().SingleInstance();
            builder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();
            var drTypes = typeFinder.FindClassesOfType<IDependencyRegister>();
            var drInstances = new List<IDependencyRegister>();
            foreach (var drType in drTypes)
                drInstances.Add((IDependencyRegister)Activator.CreateInstance(drType));

            drInstances = drInstances.AsQueryable().OrderBy(t => t.Order).ToList();
            foreach (var dependencyRegistrar in drInstances)
                dependencyRegistrar.Register(builder);
        }

        public ContainerManager ContainerManager
        {
            get { return _containerManager; }
        }
    }
}
