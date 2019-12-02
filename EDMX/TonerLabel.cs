namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TonerLabel")]
    public partial class TonerLabel
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Customer { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Goods { get; set; }

        [StringLength(20)]
        public string Material { get; set; }

        public decimal? Dosage { get; set; }

        public decimal? Subpackage { get; set; }

        public decimal? TotalQty { get; set; }

        public DateTime? DATE { get; set; }
    }
}
