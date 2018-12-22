using MemberShipManage.Domain;
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
        IPagedList<RechargeRecord> GetRechargeRecordList(int? customerID, int pageIndex, int pageSize);
        void CreateRechargeRecord(RechargeRecord rechargeRecord);
    }
}
