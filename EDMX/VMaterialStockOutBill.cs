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
    
    public partial class VMaterialStockOutBill
    {
    	[DataMember]
        public System.Guid HdID { get; set; }
    	[DataMember]
        public string 出库单号 { get; set; }
    	[DataMember]
        public System.DateTime 出库日期 { get; set; }
    	[DataMember]
        public System.DateTime 交货日期 { get; set; }
    	[DataMember]
        public string 供应商 { get; set; }
    	[DataMember]
        public string 部门 { get; set; }
    	[DataMember]
        public string 客户 { get; set; }
    	[DataMember]
        public string 联系人 { get; set; }
    	[DataMember]
        public string 仓库 { get; set; }
    	[DataMember]
        public int 类型 { get; set; }
    	[DataMember]
        public int 状态 { get; set; }
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public string 货号 { get; set; }
    	[DataMember]
        public string 品名 { get; set; }
    	[DataMember]
        public string 规格 { get; set; }
    	[DataMember]
        public decimal 数量 { get; set; }
    	[DataMember]
        public string 单位 { get; set; }
    	[DataMember]
        public decimal 单价 { get; set; }
    	[DataMember]
        public decimal 折扣 { get; set; }
    	[DataMember]
        public decimal 额外费用 { get; set; }
    	[DataMember]
        public Nullable<decimal> 金额 { get; set; }
    	[DataMember]
        public string 货品类型代码 { get; set; }
    	[DataMember]
        public string 货品类型名称 { get; set; }
    	[DataMember]
        public string 制单人 { get; set; }
    	[DataMember]
        public System.DateTime 制单日期 { get; set; }
    	[DataMember]
        public string 审核人 { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> 审核日期 { get; set; }
    	[DataMember]
        public Nullable<int> SerialNo { get; set; }
    	[DataMember]
        public string 备注 { get; set; }
    }
}
