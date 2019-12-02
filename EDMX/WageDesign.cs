namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WageDesign")]
    public partial class WageDesign
    {
        public Guid ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public decimal? Wages { get; set; }

        public decimal? Price { get; set; }

        public int? ManHour { get; set; }

        public decimal? ErrorRate { get; set; }

        public string Remark { get; set; }
    }
}
