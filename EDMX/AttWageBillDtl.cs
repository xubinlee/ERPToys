namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AttWageBillDtl")]
    public partial class AttWageBillDtl
    {
        public Guid ID { get; set; }

        public Guid HdID { get; set; }

        public Guid? UserID { get; set; }

        public int? Classes { get; set; }

        public int? Late { get; set; }

        public int? Early { get; set; }

        public int? LateCount { get; set; }

        public int? EarlyCount { get; set; }

        public int? Absent { get; set; }

        public int? Forget { get; set; }

        public int? Leave { get; set; }

        public decimal Wages { get; set; }

        public decimal Welfare { get; set; }

        public decimal Deduction { get; set; }

        public decimal SocialSecurity { get; set; }

        public decimal IndividualIncomeTax { get; set; }

        public decimal AMT { get; set; }
    }
}
