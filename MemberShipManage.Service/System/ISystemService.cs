using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Service.System
{
    public interface ISystemService
    {
        List<SystemConfig> GetSystemConfigs();
        void UpdateSystemConfig(SystemConfigRequest request);
    }
}
