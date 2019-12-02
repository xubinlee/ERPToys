namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ButtonPermission")]
    public partial class ButtonPermission
    {
        public int ID { get; set; }

        public Guid UserID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Caption { get; set; }

        public bool CheckBoxState { get; set; }
    }
}
