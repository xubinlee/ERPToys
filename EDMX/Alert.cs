namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Alert")]
    public partial class Alert
    {
        public Guid ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Caption { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Text { get; set; }

        public DateTime AddTime { get; set; }

        public Guid? GoodsID { get; set; }

        public Guid? BillID { get; set; }

        public Guid? UserID { get; set; }

        public Guid? CompanyID { get; set; }

        public Guid? SupplierID { get; set; }
    }
}
