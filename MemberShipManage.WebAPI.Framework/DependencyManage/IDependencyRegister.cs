using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Framework.DependencyManage
{
    public interface IDependencyRegister
    {
        void Register(ContainerBuilder builder);
        int Order { get; }
    }
}
