namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WageBillDtl")]
    public partial class WageBillDtl
    {
        public Guid ID { get; set; }

        public Guid HdID { get; set; }

        [StringLength(10)]
        public string YearMonth { get; set; }

        public decimal Wages { get; set; }

        public decimal Welfare { get; set; }

        public decimal Deduction { get; set; }

        public decimal SocialSecurity { get; set; }

        public decimal IndividualIncomeTax { get; set; }

        public decimal AMT { get; set; }
    }
}
