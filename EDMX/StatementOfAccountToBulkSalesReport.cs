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
    
    public partial class StatementOfAccountToBulkSalesReport
    {
    	[DataMember]
        public string 收款单号 { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> 收款日期 { get; set; }
    	[DataMember]
        public Nullable<int> 状态 { get; set; }
    	[DataMember]
        public string 客户代码 { get; set; }
    	[DataMember]
        public string 客户名称 { get; set; }
    	[DataMember]
        public string 结算类型 { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> 出库日期 { get; set; }
    	[DataMember]
        public string 货号 { get; set; }
    	[DataMember]
        public string 品名 { get; set; }
    	[DataMember]
        public Nullable<decimal> 数量 { get; set; }
    	[DataMember]
        public string 单位 { get; set; }
    	[DataMember]
        public Nullable<decimal> 净重 { get; set; }
    	[DataMember]
        public Nullable<decimal> 个数 { get; set; }
    	[DataMember]
        public Nullable<decimal> 单价 { get; set; }
    	[DataMember]
        public Nullable<decimal> 额外费用 { get; set; }
    	[DataMember]
        public Nullable<decimal> 应收金额 { get; set; }
    	[DataMember]
        public Nullable<decimal> 折扣 { get; set; }
    	[DataMember]
        public Nullable<decimal> 实收金额 { get; set; }
    	[DataMember]
        public string 货品类型代码 { get; set; }
    	[DataMember]
        public string 货品类型名称 { get; set; }
    }
}
