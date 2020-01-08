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
    
    public partial class VAppointments
    {
    	[DataMember]
        public long UniqueID { get; set; }
    	[DataMember]
        public Nullable<System.Guid> UserID { get; set; }
    	[DataMember]
        public string 工号 { get; set; }
    	[DataMember]
        public string 姓名 { get; set; }
    	[DataMember]
        public int 工资状态 { get; set; }
    	[DataMember]
        public string 年月 { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> 日期 { get; set; }
    	[DataMember]
        public Nullable<int> 班次 { get; set; }
    	[DataMember]
        public Nullable<int> 机号 { get; set; }
    	[DataMember]
        public Nullable<System.Guid> GoodsID { get; set; }
    	[DataMember]
        public string 货号 { get; set; }
    	[DataMember]
        public string 品名 { get; set; }
    	[DataMember]
        public Nullable<decimal> 重量_斤 { get; set; }
    	[DataMember]
        public Nullable<decimal> 净重_克 { get; set; }
    	[DataMember]
        public Nullable<decimal> 计算周期 { get; set; }
    	[DataMember]
        public Nullable<int> 应产模数 { get; set; }
    	[DataMember]
        public Nullable<int> 实产模数 { get; set; }
    	[DataMember]
        public Nullable<decimal> 工时 { get; set; }
    	[DataMember]
        public Nullable<decimal> 当班金额 { get; set; }
    	[DataMember]
        public string 备注 { get; set; }
    }
}
