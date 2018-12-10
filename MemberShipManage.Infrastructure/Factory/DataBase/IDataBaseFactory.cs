using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Infrastructure.Factory.DataBase
{
    public interface IDataBaseFactory
    {
        DbContext Get(string connectionString);
    }
}
