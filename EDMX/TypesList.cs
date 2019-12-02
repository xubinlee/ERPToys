namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TypesList")]
    public partial class TypesList
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string Type { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int No { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        public string SubType { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}
