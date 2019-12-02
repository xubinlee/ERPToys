namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Appointments
    {
        [Key]
        public long UniqueID { get; set; }

        public Guid? UserID { get; set; }

        public Guid? GoodsID { get; set; }

        public decimal? Weight { get; set; }

        public decimal? NWeight { get; set; }

        [StringLength(50)]
        public string Machine { get; set; }

        public decimal? Cycle { get; set; }

        public decimal? ManHour { get; set; }

        public decimal? ErrorRate { get; set; }

        public decimal? Price { get; set; }

        public decimal? Wages { get; set; }

        public Guid? WageDesignID { get; set; }

        public int? PlanYield { get; set; }

        public int? Yielded { get; set; }

        public decimal? AMT { get; set; }

        public int? Type { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool? AllDay { get; set; }

        [StringLength(50)]
        public string Subject { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public int? Status { get; set; }

        public int? Label { get; set; }

        public int? ResourceID { get; set; }

        public string RecurrenceInfo { get; set; }

        public string ReminderInfo { get; set; }

        [StringLength(50)]
        public string CustomField1 { get; set; }

        public int WageStatus { get; set; }
    }
}
