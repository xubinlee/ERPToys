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
    
    public partial class VStatementOfAccountToSupplier
    {
    	[DataMember]
        public string 供应商代码 { get; set; }
    	[DataMember]
        public string 供应商名称 { get; set; }
    	[DataMember]
        public string 结算类型 { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> 结算日期 { get; set; }
    	[DataMember]
        public string 货号 { get; set; }
    	[DataMember]
        public string 品名 { get; set; }
    	[DataMember]
        public Nullable<decimal> 数量 { get; set; }
    	[DataMember]
        public string 单位 { get; set; }
    	[DataMember]
        public decimal 单价 { get; set; }
    	[DataMember]
        public decimal 折扣 { get; set; }
    	[DataMember]
        public decimal 额外费用 { get; set; }
    	[DataMember]
        public string 规格 { get; set; }
    	[DataMember]
        public string 货品类型代码 { get; set; }
    	[DataMember]
        public string 货品类型名称 { get; set; }
    }
}
