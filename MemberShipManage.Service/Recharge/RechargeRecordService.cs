using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure.UnitOfWork;
using MemberShipManage.Repository.Recharge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;

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

        public IPagedList<RechargeRecord> GetRechargeRecordList(RechargeListRequest request)
        {
            return rechargeRecordRepository.GetRechargeRecordList(request);
        }

        public void CreateRechargeRecord(RechargeRecord rechargeRecord)
        {
            rechargeRecordRepository.Insert(rechargeRecord);
            unitOfWork.Commit();
        }

        public string RecallRecharge(int rechargeRecordID)
        {
            return rechargeRecordRepository.RecallRecharge(rechargeRecordID);
        }
    }
}
