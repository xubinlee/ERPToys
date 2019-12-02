namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AttWageBillHd")]
    public partial class AttWageBillHd
    {
        public Guid ID { get; set; }

        [Required]
        [StringLength(30)]
        public string BillNo { get; set; }

        public DateTime BillDate { get; set; }

        [StringLength(10)]
        public string YearMonth { get; set; }

        public decimal? Balance { get; set; }

        public int Status { get; set; }

        public Guid Maker { get; set; }

        public DateTime MakeDate { get; set; }

        public Guid? Auditor { get; set; }

        public DateTime? AuditDate { get; set; }

        public string Remark { get; set; }
    }
}
