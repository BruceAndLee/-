//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MemberShipManage.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class ConsumeRecord
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public decimal Amount { get; set; }
        public string Detail { get; set; }
        public Nullable<System.DateTime> InDate { get; set; }
        public string InUser { get; set; }
    }
}
