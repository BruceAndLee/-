using Autofac;
using MemberShipManage.Infrastructure.Factory.DataBase;
using MemberShipManage.Infrastructure.UnitOfWork;
using MemberShipManage.Repository.CustomerManage;
using MemberShipManage.Service.CustomerManage;
using System.Configuration;

namespace MemberShipManage.Framework.DependencyManage
{
    public class DependencyRegister : IDependencyRegister
    {
        public virtual void Register(ContainerBuilder builder)
        {
            builder.RegisterType<DatabaseFactory>().As<IDataBaseFactory>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().WithParameter("connectionString", ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString).InstancePerLifetimeScope();
            #region Repository

            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().InstancePerLifetimeScope();

            #endregion

            #region Service

            builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerLifetimeScope();

            #endregion
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
