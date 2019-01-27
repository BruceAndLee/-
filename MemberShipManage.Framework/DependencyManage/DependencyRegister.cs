using Autofac;
using MemberShipManage.Infrastructure.Factory.DataBase;
using MemberShipManage.Infrastructure.UnitOfWork;
using MemberShipManage.Repository.Consume;
using MemberShipManage.Repository.CustomerManage;
using MemberShipManage.Repository.Recharge;
using MemberShipManage.Repository.System;
using MemberShipManage.Repository.UserManage;
using MemberShipManage.Service.Consume;
using MemberShipManage.Service.CustomerManage;
using MemberShipManage.Service.Recharge;
using MemberShipManage.Service.System;
using MemberShipManage.Service.UserManage;
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
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerAmountRepository>().As<ICustomerAmountRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RechargeRecordRepository>().As<IRechargeRecordRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ConsumeRecordRepository>().As<IConsumeRecordRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SystemRepository>().As<ISystemRepository>().InstancePerLifetimeScope();

            #endregion

            #region Service

            builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerAmountService>().As<ICustomerAmountService>().InstancePerLifetimeScope();
            builder.RegisterType<RechargeRecordService>().As<IRechargeRecordService>().InstancePerLifetimeScope();
            builder.RegisterType<ConsumeRecordService>().As<IConsumeRecordService>().InstancePerLifetimeScope();
            builder.RegisterType<SystemService>().As<ISystemService>().InstancePerLifetimeScope();

            #endregion
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
