//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dao
{
    using System;
    using System.Collections.Generic;
    
    public partial class AP_Area
    {
        public System.Guid Id { get; set; }
        public int SeqNo { get; set; }
        public string Code { get; set; }
        public int Status { get; set; }
        public int Flag { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.Guid CreateUser { get; set; }
        public System.Guid LastModifyUser { get; set; }
        public System.DateTime LastModifyTime { get; set; }
        public string Name { get; set; }
        public System.Guid ParentId { get; set; }
        public int Type { get; set; }
    }
}
