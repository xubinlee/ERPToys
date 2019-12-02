namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USPAttWageBillDtl")]
    public partial class USPAttWageBillDtl
    {
        [Key]
        [Column(Order = 0)]
        public bool CheckItem { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid UserID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(10)]
        public string YearMonth { get; set; }

        public int? Classes { get; set; }

        public int? Late { get; set; }

        public int? Early { get; set; }

        public int? LateCount { get; set; }

        public int? EarlyCount { get; set; }

        public int? Absent { get; set; }

        public int? Forget { get; set; }

        public int? Leave { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal Wages { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal Welfare { get; set; }

        [Key]
        [Column(Order = 5)]
        public decimal Deduction { get; set; }

        [Key]
        [Column(Order = 6)]
        public decimal SocialSecurity { get; set; }

        [Key]
        [Column(Order = 7)]
        public decimal IndividualIncomeTax { get; set; }

        [Key]
        [Column(Order = 8)]
        public decimal AMT { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WageStatus { get; set; }
    }
}
