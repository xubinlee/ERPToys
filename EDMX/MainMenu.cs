namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MainMenu")]
    public partial class MainMenu
    {
        public Guid ID { get; set; }

        public Guid? ParentID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SerialNo { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Caption { get; set; }

        [StringLength(20)]
        public string Subtitle { get; set; }

        [StringLength(10)]
        public string Prefix { get; set; }

        [Column(TypeName = "ntext")]
        public string ImagePath { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public bool CheckBoxState { get; set; }
    }
}
