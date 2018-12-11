using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Infrastructure.RestAPI
{
    public class APIBaseResponse
    {
        public bool IsSuccess { get; set; }
        public string ResponseCode { get; set; }
        public string ErrorMessage { get; set; }

        public APIBaseResponse()
        { }

        public APIBaseResponse(bool isSuccess)
        {
            this.IsSuccess = isSuccess;
        }

        public APIBaseResponse(bool isSuccess, string responseCode)
            : this(isSuccess)
        {
            this.IsSuccess = isSuccess;
            this.ResponseCode = responseCode;
        }

        public APIBaseResponse(bool isSuccess, string responseCode, string errorMessage)
            : this(isSuccess, responseCode)
        {
            this.ResponseCode = responseCode;
            this.ErrorMessage = errorMessage;
        }
    }
}
