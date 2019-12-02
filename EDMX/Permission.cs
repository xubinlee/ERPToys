namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Permission")]
    public partial class Permission
    {
        public int ID { get; set; }

        public int ParentID { get; set; }

        public int SerialNo { get; set; }

        [Key]
        [Column(Order = 0)]
        public Guid UserID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string Caption { get; set; }

        public bool CheckBoxState { get; set; }
    }
}
