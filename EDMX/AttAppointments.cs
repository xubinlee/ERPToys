namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AttAppointments
    {
        [Key]
        public long UniqueID { get; set; }

        public Guid? GLogStartID { get; set; }

        public Guid? GLogEndID { get; set; }

        public Guid? UserID { get; set; }

        public Guid? SchClassID { get; set; }

        [Required]
        [StringLength(20)]
        public string SchClassName { get; set; }

        public int SchSerialNo { get; set; }

        public DateTime? SchStartTime { get; set; }

        public DateTime? SchEndTime { get; set; }

        public DateTime? CheckInTime { get; set; }

        public DateTime? CheckOutTime { get; set; }

        public int? LateMinutes { get; set; }

        public int? EarlyMinutes { get; set; }

        public int AttStatus { get; set; }

        public int? Type { get; set; }

        public bool? AllDay { get; set; }

        [StringLength(50)]
        public string Subject { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        public int? ResourceID { get; set; }

        public string RecurrenceInfo { get; set; }

        public string ReminderInfo { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public int WageStatus { get; set; }
    }
}
