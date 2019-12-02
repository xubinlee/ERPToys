namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inventory")]
    public partial class Inventory
    {
        public Guid ID { get; set; }

        public Guid WarehouseID { get; set; }

        public int WarehouseType { get; set; }

        public Guid? CompanyID { get; set; }

        public Guid? SupplierID { get; set; }

        public Guid? DeptID { get; set; }

        public Guid GoodsID { get; set; }

        public decimal Qty { get; set; }

        [StringLength(20)]
        public string MEAS { get; set; }

        public int PCS { get; set; }

        public int InnerBox { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public decimal OtherFee { get; set; }

        public DateTime EntryDate { get; set; }

        [Required]
        [StringLength(30)]
        public string BillNo { get; set; }

        public DateTime BillDate { get; set; }

        public decimal NWeight { get; set; }
    }
}
