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
    
    public partial class Customer
    {
        public int ID { get; set; }
        public string UserNo { get; set; }
        public Nullable<int> Sex { get; set; }
        public Nullable<System.DateTime> InDate { get; set; }
        public Nullable<int> InUser { get; set; }
        public string Name { get; set; }
        public int ParentID { get; set; }
    }
}
