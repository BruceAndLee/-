using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure.UnitOfWork;
using MemberShipManage.Repository.System;
using System.Collections.Generic;

namespace MemberShipManage.Service.System
{
    public class SystemService : BaseService, ISystemService
    {
        ISystemRepository systemRepository;
        IUnitOfWork unitOfWork;
        public SystemService(
            ISystemRepository systemRepository,
            IUnitOfWork unitOfWork)
        {
            this.systemRepository = systemRepository;
            this.unitOfWork = unitOfWork;
        }

        public List<SystemConfig> GetSystemConfigs()
        {
            return systemRepository.GetSystemConfigs();
        }

        public void UpdateSystemConfig(SystemConfigRequest request)
        {
            var systemConfig = systemRepository.GetSystemConfig(request.ConfigKey);
            if (systemConfig != null)
            {
                systemConfig.ConfigValue = request.ConfigValue;
                systemConfig.Display = request.Display;
                systemRepository.Update(systemConfig);
                unitOfWork.Commit();
            }
        }
    }
}
