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
    
    public partial class VReceiptBill
    {
        public System.Guid HdID { get; set; }
        public string 收款单号 { get; set; }
        public System.DateTime 收款日期 { get; set; }
        public int 收款类型 { get; set; }
        public int 状态 { get; set; }
        public Nullable<System.Guid> CompanyID { get; set; }
        public string 客户代码 { get; set; }
        public string 客户名称 { get; set; }
        public Nullable<int> 客户类型 { get; set; }
        public Nullable<System.Guid> SupplierID { get; set; }
        public string 供应商代码 { get; set; }
        public string 供应商名称 { get; set; }
        public string 联系人 { get; set; }
        public int 结算方式 { get; set; }
        public System.Guid ID { get; set; }
        public System.Guid BillID { get; set; }
        public string 单据编号 { get; set; }
        public System.DateTime 单据日期 { get; set; }
        public int 类型 { get; set; }
        public decimal 单据金额 { get; set; }
        public decimal 已收金额 { get; set; }
        public Nullable<decimal> 未收金额 { get; set; }
        public decimal 本次收款 { get; set; }
        public string 制单人 { get; set; }
        public System.DateTime 制单日期 { get; set; }
        public string 审核人 { get; set; }
        public Nullable<System.DateTime> 审核日期 { get; set; }
        public string 备注 { get; set; }
    }
}