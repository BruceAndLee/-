using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;

namespace MemberShipManage.Service.Recharge
{
    public interface IRechargeRecordService
    {
        void CreateRechargeRecord(RechargeRecord rechargeRecord);
        PagedList<RechargeRecord> GetRechargeRecordList(RechargeListRequest request);
        string RecallRecharge(int rechargeRecordID);
    }
}
