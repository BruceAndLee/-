using MemberShipManage.Domain;
using PersonalSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Repository.System
{
    public interface ISystemRepository : IRepository<SystemConfig>
    {
        List<SystemConfig> GetSystemConfigs();
        SystemConfig GetSystemConfig(string configKey);
    }
}
