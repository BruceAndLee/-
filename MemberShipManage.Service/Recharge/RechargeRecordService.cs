using MemberShipManage.Domain;
using MemberShipManage.Infrastructure.UnitOfWork;
using MemberShipManage.Repository.Recharge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Service.Recharge
{
    public class RechargeRecordService : BaseService, IRechargeRecordService
    {
        IRechargeRecordRepository rechargeRecordRepository;
        IUnitOfWork unitOfWork;
        public RechargeRecordService(
            IRechargeRecordRepository rechargeRecordRepository
            , IUnitOfWork unitOfWork)
        {
            this.rechargeRecordRepository = rechargeRecordRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateRechargeRecord(RechargeRecord rechargeRecord)
        {
            rechargeRecordRepository.CreateRechargeRecord(rechargeRecord);
            unitOfWork.Commit();
        }
    }
}
