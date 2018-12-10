using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Framework
{
    public interface IAppStartManager
    { /// <summary>
      /// Container manager
      /// </summary>
        ContainerManager ContainerManager { get; }

        /// <summary>
        /// Initialize components and plugins in the nop environment.
        /// </summary>
        /// <param name="config">Config</param>
        void Initialize(Assembly assembly, Action<ContainerBuilder, Assembly> registerAPIController = null, Action<IContainer> setDependencyResolver = null);
    }
}
