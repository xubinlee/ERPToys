namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SchClass")]
    public partial class SchClass
    {
        public Guid ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public int SerialNo { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int LateMinutes { get; set; }

        public int EarlyMinutes { get; set; }

        public DateTime? CheckInStartTime { get; set; }

        public DateTime? CheckInEndTime { get; set; }

        public DateTime? CheckOutStartTime { get; set; }

        public DateTime? CheckOutEndTime { get; set; }

        public int? Color { get; set; }
    }
}
