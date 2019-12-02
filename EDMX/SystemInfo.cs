namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SystemInfo")]
    public partial class SystemInfo
    {
        [Key]
        [StringLength(50)]
        public string Company { get; set; }

        public int CompanyType { get; set; }

        [StringLength(100)]
        public string Contracts { get; set; }

        [StringLength(500)]
        public string Accounts { get; set; }

        [StringLength(50)]
        public string FtpPath { get; set; }

        [StringLength(20)]
        public string ServerUserName { get; set; }

        [StringLength(50)]
        public string ServerPassword { get; set; }

        [StringLength(20)]
        public string Version { get; set; }
    }
}
