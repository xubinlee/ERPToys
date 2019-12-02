namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOM")]
    public partial class BOM
    {
        [Key]
        [Column(Order = 0)]
        public Guid GoodsID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid ParentGoodsID { get; set; }

        public decimal Qty { get; set; }

        public int PCS { get; set; }

        public int InnerBox { get; set; }

        public decimal Price { get; set; }

        public decimal PriceNoTax { get; set; }

        public int Type { get; set; }

        public decimal Discount { get; set; }

        public decimal OtherFee { get; set; }

        [StringLength(100)]
        public string Remark { get; set; }
    }
}
