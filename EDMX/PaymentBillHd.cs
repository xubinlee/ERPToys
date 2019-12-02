namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PaymentBillHd")]
    public partial class PaymentBillHd
    {
        public Guid ID { get; set; }

        [Key]
        [StringLength(30)]
        public string BillNo { get; set; }

        public DateTime BillDate { get; set; }

        public Guid? CompanyID { get; set; }

        public Guid? SupplierID { get; set; }

        [StringLength(20)]
        public string Contacts { get; set; }

        public int BillType { get; set; }

        public int POClear { get; set; }

        public Guid Maker { get; set; }

        public DateTime MakeDate { get; set; }

        public Guid? Auditor { get; set; }

        public DateTime? AuditDate { get; set; }

        [Column(TypeName = "ntext")]
        public string Remark { get; set; }

        public int Status { get; set; }

        public decimal? Balance { get; set; }

        public decimal? PaidAMT { get; set; }

        public decimal? UnPaidAMT { get; set; }

        [Column(TypeName = "image")]
        public byte[] Pic { get; set; }
    }
}
