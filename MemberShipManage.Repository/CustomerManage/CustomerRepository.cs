using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure;
using MemberShipManage.Infrastructure.UnitOfWork;
using MemberShipManage.Utility;
using PersonalSite.Repository;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Webdiyer.WebControls.Mvc;

namespace MemberShipManage.Repository.CustomerManage
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork dbcontext)
            : base(dbcontext)
        {

        }

        public bool CheckCustomerExists(string userNo, string password)
        {
            var user = GetCustomer(userNo);

            if (user == null)
            {
                return false;
            }

            var passwordDb = Cryptor.Decrypt(user.Password);
            if (password != passwordDb)
            {
                return false;
            }

            return true;
        }

        public Customer GetCustomer(string userNo)
        {
            return dbSet.FirstOrDefault(d => d.UserNo == userNo);
        }

        public Customer GetCustomer(int customerID)
        {
            return dbSet.FirstOrDefault(d => d.ID == customerID);
        }

        public decimal GetCustomerBalance(string userNo)
        {
            var user = dbSet.FirstOrDefault(d => d.UserNo == userNo);
            if (user != null
                && user.CustomerAmount != null
                && user.CustomerAmount.Count > 0)
            {
                return user.CustomerAmount.First().Amount;
            }

            return 0;
        }

        public IPagedList<CustomerEntity> GetCustomerList(CustomerListRequest request)
        {
            var sqlScript = DBScriptManager.GetScript(this.GetType(), "GetCustomerList");

            var paramTotal = new SqlParameter("@TotalCount", SqlDbType.Int);
            paramTotal.Direction = ParameterDirection.Output;

            var paramUserNo = new SqlParameter("@UserNo", SqlDbType.VarChar, 25);
            paramUserNo.Value = request.UserNo ?? string.Empty;

            var paramName = new SqlParameter("@Name", SqlDbType.NVarChar, 20);
            paramName.Value = request.Name ?? string.Empty;

            var paramSex = new SqlParameter("@Sex", SqlDbType.Int);
            if (!request.Sex.HasValue)
            {
                paramSex.Value = DBNull.Value;
            }
            else
            {
                paramSex.Value = request.Sex;
            }

            var paramPageIndex = new SqlParameter("@PageIndex", SqlDbType.Int);
            paramPageIndex.Value = request.PageIndex - 1;

            var paramPageSize = new SqlParameter("@PageSize", SqlDbType.Int);
            paramPageSize.Value = request.PageSize;

            var query = ExecuteSqlQuery<CustomerEntity>(sqlScript
                , new SqlParameter[]
                {
                    paramUserNo,
                    paramName,
                    paramSex,
                    paramPageIndex,
                    paramPageSize,
                    paramTotal
                });

            return new PagedList<CustomerEntity>(query.ToList(),
                request.PageIndex,
                request.PageSize,
                Convert.ToInt32(paramTotal.Value));
        }
    }
}
