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
    
    public partial class AnnualSalesSummaryByCustomerReport
    {
    	[DataMember]
        public string 客户代码 { get; set; }
    	[DataMember]
        public string 客户名称 { get; set; }
    	[DataMember]
        public Nullable<int> 客户类型 { get; set; }
    	[DataMember]
        public string 年月 { get; set; }
    	[DataMember]
        public Nullable<decimal> 箱数 { get; set; }
    	[DataMember]
        public Nullable<decimal> 总数量 { get; set; }
    	[DataMember]
        public Nullable<decimal> 金额 { get; set; }
    	[DataMember]
        public Nullable<decimal> 已收金额 { get; set; }
    	[DataMember]
        public Nullable<decimal> 未收金额 { get; set; }
    }
}
