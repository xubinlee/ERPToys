//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EDMX
{
    using System;
    using System.Collections.Generic;
    
    public partial class VStaffSchClass
    {
        public System.Guid ID { get; set; }
        public System.Guid DeptID { get; set; }
        public System.Guid SchClassID { get; set; }
        public int SchSerialNo { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public int LateMinutes { get; set; }
        public int EarlyMinutes { get; set; }
        public Nullable<System.DateTime> CheckInStartTime { get; set; }
        public Nullable<System.DateTime> CheckInEndTime { get; set; }
        public Nullable<System.DateTime> CheckOutStartTime { get; set; }
        public Nullable<System.DateTime> CheckOutEndTime { get; set; }
        public Nullable<int> Color { get; set; }
    }
}