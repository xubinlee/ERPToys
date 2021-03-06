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
    [KnownType(typeof(ReceiptBillDtl))]
    
    public partial class ReceiptBillHd
    {
        public ReceiptBillHd()
        {
            this.ReceiptBillDtl = new HashSet<ReceiptBillDtl>();
        }
    
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public string BillNo { get; set; }
    	[DataMember]
        public System.DateTime BillDate { get; set; }
    	[DataMember]
        public Nullable<System.Guid> CompanyID { get; set; }
    	[DataMember]
        public Nullable<System.Guid> SupplierID { get; set; }
    	[DataMember]
        public string Contacts { get; set; }
    	[DataMember]
        public int BillType { get; set; }
    	[DataMember]
        public int POClear { get; set; }
    	[DataMember]
        public System.Guid Maker { get; set; }
    	[DataMember]
        public System.DateTime MakeDate { get; set; }
    	[DataMember]
        public Nullable<System.Guid> Auditor { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> AuditDate { get; set; }
    	[DataMember]
        public string Remark { get; set; }
    	[DataMember]
        public int Status { get; set; }
    	[DataMember]
        public Nullable<decimal> Balance { get; set; }
    	[DataMember]
        public Nullable<decimal> ReceiptedAMT { get; set; }
    	[DataMember]
        public Nullable<decimal> UnReceiptedAMT { get; set; }
    	[DataMember]
        public byte[] Pic { get; set; }
    
    	[DataMember]
        public virtual ICollection<ReceiptBillDtl> ReceiptBillDtl { get; set; }
    }
}
