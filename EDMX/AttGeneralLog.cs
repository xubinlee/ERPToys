namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AttGeneralLog")]
    public partial class AttGeneralLog
    {
        public Guid ID { get; set; }

        [Required]
        [StringLength(20)]
        public string EnrollNumber { get; set; }

        public int VerifyMode { get; set; }

        public int InOutMode { get; set; }

        public DateTime AttTime { get; set; }

        public int Workcode { get; set; }

        public bool AttFlag { get; set; }

        public int AttStatus { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public Guid? SchClassID { get; set; }
    }
}
