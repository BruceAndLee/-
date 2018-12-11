using MemberShipManage.Infrastructure;
using MemberShipManage.Infrastructure.RestAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Service
{
    public class BaseService
    {
        protected APIBaseResponse BuildAPIErrorResponse(string responseCode)
        {
            return new APIBaseResponse(false, responseCode, MsgResourceBuilder.GetMessageResource(responseCode));
        }

        protected APIBaseResponse BuildAPIErrorResponse(string responseCode, object[] parameters)
        {
            return new APIBaseResponse(false, responseCode, string.Format(MsgResourceBuilder.GetMessageResource(responseCode), parameters));
        }

        protected APIBaseResponse BuildAPISucResponse(string responseCode = "")
        {
            return new APIBaseResponse(true, responseCode);
        }
    }
}
