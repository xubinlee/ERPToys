namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Department")]
    public partial class Department
    {
        public Guid ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Key]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Contacts { get; set; }

        [StringLength(50)]
        public string ContactTel { get; set; }

        [StringLength(50)]
        public string ContactCellPhone { get; set; }

        [StringLength(50)]
        public string QQ { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        public int Type { get; set; }

        public int Status { get; set; }

        public DateTime AddTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        [Column(TypeName = "ntext")]
        public string Remark { get; set; }
    }
}
