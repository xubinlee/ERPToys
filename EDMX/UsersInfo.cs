namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsersInfo")]
    public partial class UsersInfo
    {
        public Guid ID { get; set; }

        [Key]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Password { get; set; }

        public Guid? DeptID { get; set; }

        [StringLength(10)]
        public string Post { get; set; }

        [StringLength(20)]
        public string Tel { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(20)]
        public string DormNo { get; set; }

        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }

        public Guid? RoleID { get; set; }

        [Column(TypeName = "xml")]
        public string Permissions { get; set; }

        [Column(TypeName = "ntext")]
        public string Remark { get; set; }

        [StringLength(20)]
        public string AttCardnumber { get; set; }

        public int AttPrivilege { get; set; }

        public bool AttEnabled { get; set; }

        public int WageType { get; set; }

        public decimal Wages { get; set; }

        public decimal SchClassWage { get; set; }

        public decimal TimeWage { get; set; }

        public bool IsDel { get; set; }
    }
}
