namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AttParameters
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MachineNumber { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string CommMode { get; set; }

        [StringLength(10)]
        public string BaudRate { get; set; }

        [StringLength(20)]
        public string AttIP { get; set; }

        [StringLength(10)]
        public string AttPort { get; set; }
    }
}
