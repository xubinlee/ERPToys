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
    
    public partial class VPaymentBill
    {
    	[DataMember]
        public System.Guid HdID { get; set; }
    	[DataMember]
        public string 付款单号 { get; set; }
    	[DataMember]
        public System.DateTime 付款日期 { get; set; }
    	[DataMember]
        public int 付款类型 { get; set; }
    	[DataMember]
        public int 状态 { get; set; }
    	[DataMember]
        public Nullable<System.Guid> CompanyID { get; set; }
    	[DataMember]
        public string 客户代码 { get; set; }
    	[DataMember]
        public string 客户名称 { get; set; }
    	[DataMember]
        public Nullable<int> 客户类型 { get; set; }
    	[DataMember]
        public Nullable<System.Guid> SupplierID { get; set; }
    	[DataMember]
        public string 供应商代码 { get; set; }
    	[DataMember]
        public string 供应商名称 { get; set; }
    	[DataMember]
        public string 工人 { get; set; }
    	[DataMember]
        public string 联系人 { get; set; }
    	[DataMember]
        public int 结算方式 { get; set; }
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public System.Guid BillID { get; set; }
    	[DataMember]
        public string 单据编号 { get; set; }
    	[DataMember]
        public System.DateTime 单据日期 { get; set; }
    	[DataMember]
        public int 类型 { get; set; }
    	[DataMember]
        public decimal 单据金额 { get; set; }
    	[DataMember]
        public decimal 已付金额 { get; set; }
    	[DataMember]
        public Nullable<decimal> 未付金额 { get; set; }
    	[DataMember]
        public decimal 本次付款 { get; set; }
    	[DataMember]
        public string 制单人 { get; set; }
    	[DataMember]
        public System.DateTime 制单日期 { get; set; }
    	[DataMember]
        public string 审核人 { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> 审核日期 { get; set; }
    	[DataMember]
        public string 备注 { get; set; }
    }
}
