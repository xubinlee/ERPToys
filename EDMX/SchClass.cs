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
    using System.Runtime.Serialization;
    using System.Collections.Generic;
    
    [DataContract(IsReference = true)]
    
    public partial class SchClass
    {
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public string Name { get; set; }
    	[DataMember]
        public int SerialNo { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> StartTime { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> EndTime { get; set; }
    	[DataMember]
        public int LateMinutes { get; set; }
    	[DataMember]
        public int EarlyMinutes { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> CheckInStartTime { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> CheckInEndTime { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> CheckOutStartTime { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> CheckOutEndTime { get; set; }
    	[DataMember]
        public Nullable<int> Color { get; set; }
    }
}
