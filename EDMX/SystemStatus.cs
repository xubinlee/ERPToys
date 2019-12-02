namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SystemStatus
    {
        [Key]
        [StringLength(50)]
        public string MainMenuName { get; set; }

        [StringLength(30)]
        public string MaxBillNo { get; set; }

        public int Status { get; set; }
    }
}
