namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    public partial class Supplier
    {
        public Guid ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(6)]
        public string PostCode { get; set; }

        [StringLength(20)]
        public string Contacts { get; set; }

        [StringLength(50)]
        public string ContactTel { get; set; }

        [StringLength(50)]
        public string ContactCellPhone { get; set; }

        [StringLength(50)]
        public string QQ { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [StringLength(50)]
        public string ACBank { get; set; }

        [StringLength(20)]
        public string ACNo { get; set; }

        [StringLength(20)]
        public string Tax { get; set; }

        [StringLength(50)]
        public string PaymentAddr { get; set; }

        [StringLength(50)]
        public string PaymentTitle { get; set; }

        [StringLength(50)]
        public string InvoiceAddr { get; set; }

        public int Type { get; set; }

        public int Status { get; set; }

        public DateTime AddTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        [Column(TypeName = "ntext")]
        public string Remark { get; set; }
    }
}