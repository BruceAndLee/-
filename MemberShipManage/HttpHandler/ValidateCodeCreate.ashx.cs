using PersonalSite.Utility;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.SessionState;

namespace MemberShipManage.HttpHandler
{
    /// <summary>
    /// ValidateCode 的摘要说明
    /// </summary>
    public class ValidateCodeCreate : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            var vCode = new ValidateCodeHelper();
            string code = vCode.CreateValidateCode(5);
            context.Session["ValidateCode"] = code;
            byte[] bytes = vCode.CreateValidateGraphic(code);
            MemoryStream ms = new MemoryStream(bytes);
            Bitmap bitmap = new Bitmap(ms);
            bitmap.Save(context.Response.OutputStream, ImageFormat.Jpeg);
            context.Response.ContentType = "image/jpg";
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}