using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Infrastructure.Factory.DataBase
{
    public class DatabaseFactory : IDisposable, IDataBaseFactory
    {
        private DbContext _database;

        public DatabaseFactory()
        {

        }

        public virtual DbContext Get(string connectionString)
        {
            if (_database == null)
            {
                _database = new DbContext(connectionString);
            }

            return _database;
        }

        public void Dispose()
        {
            if (_database != null)
            {
                _database.Dispose();
            }
        }
    }
}
