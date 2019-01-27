using MemberShipManage.Domain;
using MemberShipManage.Infrastructure.UnitOfWork;
using PersonalSite.Repository;
using System.Collections.Generic;
using System.Linq;

namespace MemberShipManage.Repository.System
{
    public class SystemRepository : BaseRepository<SystemConfig>, ISystemRepository
    {
        public SystemRepository(IUnitOfWork dbcontext)
           : base(dbcontext)
        { }

        public List<SystemConfig> GetSystemConfigs()
        {
            return dbSet.ToList();
        }

        public SystemConfig GetSystemConfig(string configKey)
        {
            return dbSet.FirstOrDefault(d => d.ConfigKey == configKey);
        }
    }
}
