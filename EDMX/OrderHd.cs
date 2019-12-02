namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderHd")]
    public partial class OrderHd
    {
        public Guid ID { get; set; }

        [Key]
        [StringLength(30)]
        public string BillNo { get; set; }

        public Guid WarehouseID { get; set; }

        public int WarehouseType { get; set; }

        public Guid? CompanyID { get; set; }

        public Guid? SupplierID { get; set; }

        [StringLength(20)]
        public string Contacts { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public Guid Maker { get; set; }

        public DateTime MakeDate { get; set; }

        public Guid? Auditor { get; set; }

        public DateTime? AuditDate { get; set; }

        [Column(TypeName = "ntext")]
        public string MainMark { get; set; }

        [Column(TypeName = "ntext")]
        public string Remark { get; set; }

        public int Type { get; set; }

        public int Status { get; set; }

        public int BillType { get; set; }

        public decimal? BillAMT { get; set; }

        public decimal? UnReceiptedAMT { get; set; }

        [Column(TypeName = "image")]
        public byte[] Pic { get; set; }
    }
}
