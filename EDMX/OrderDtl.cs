namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDtl")]
    public partial class OrderDtl
    {
        public Guid ID { get; set; }

        public Guid HdID { get; set; }

        public int? SerialNo { get; set; }

        public Guid GoodsID { get; set; }

        public decimal Qty { get; set; }

        [StringLength(20)]
        public string MEAS { get; set; }

        public int PCS { get; set; }

        public int InnerBox { get; set; }

        public decimal Price { get; set; }

        public decimal PriceNoTax { get; set; }

        public decimal Discount { get; set; }

        public decimal OtherFee { get; set; }

        [Column(TypeName = "ntext")]
        public string MainMark { get; set; }

        [Column(TypeName = "ntext")]
        public string SideMark { get; set; }

        [Column(TypeName = "ntext")]
        public string InnerMark { get; set; }

        public decimal NWeight { get; set; }

        public decimal? Modulus { get; set; }

        public string Remark { get; set; }

        public virtual Goods Goods { get; set; }
    }
}
