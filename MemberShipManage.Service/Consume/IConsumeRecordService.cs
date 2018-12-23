using MemberShipManage.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;

namespace MemberShipManage.Service.Consume
{
    public interface IConsumeRecordService
    {
        IPagedList<ConsumeRecord> GetConsumeRecordList(string userNo, int pageIndex, int pageSize);
    }
}
