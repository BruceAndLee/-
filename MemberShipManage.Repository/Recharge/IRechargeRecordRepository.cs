using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using PersonalSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;

namespace MemberShipManage.Repository.Recharge
{
    public interface IRechargeRecordRepository : IRepository<RechargeRecord>
    {
        PagedList<RechargeRecord> GetRechargeRecordList(RechargeListRequest request);
        string RecallRecharge(int rechargeRecordID);
    }
}
