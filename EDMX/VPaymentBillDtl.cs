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
    
    public partial class VPaymentBillDtl
    {
    	[DataMember]
        public Nullable<bool> CheckItem { get; set; }
    	[DataMember]
        public System.Guid BillID { get; set; }
    	[DataMember]
        public Nullable<System.Guid> CompanyID { get; set; }
    	[DataMember]
        public Nullable<System.Guid> SupplierID { get; set; }
    	[DataMember]
        public string BillNo { get; set; }
    	[DataMember]
        public System.DateTime BillDate { get; set; }
    	[DataMember]
        public int Type { get; set; }
    	[DataMember]
        public Nullable<decimal> BillAMT { get; set; }
    	[DataMember]
        public Nullable<decimal> PaidAMT { get; set; }
    	[DataMember]
        public Nullable<decimal> UnPaidAMT { get; set; }
    	[DataMember]
        public Nullable<decimal> LastPaidAMT { get; set; }
    	[DataMember]
        public int Status { get; set; }
    	[DataMember]
        public string Remark { get; set; }
    	[DataMember]
        public Nullable<System.Guid> Worker { get; set; }
    }
}
