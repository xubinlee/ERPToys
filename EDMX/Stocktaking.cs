namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stocktaking")]
    public partial class Stocktaking
    {
        [Required]
        [StringLength(50)]
        public string Warehouse { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WarehouseType { get; set; }

        public Guid? SupplierID { get; set; }

        public int GoodsBigType { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string Goods { get; set; }

        public decimal Qty { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PCS { get; set; }

        [StringLength(20)]
        public string MEAS { get; set; }

        [Required]
        [StringLength(20)]
        public string Checker { get; set; }

        public DateTime CheckingDate { get; set; }
    }
}
