namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SLSalePrice")]
    public partial class SLSalePrice
    {
        [Key]
        [Column(Order = 0)]
        public Guid ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid GoodsID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Type { get; set; }

        public decimal Price { get; set; }

        public decimal PriceNoTax { get; set; }

        public decimal Discount { get; set; }

        public decimal OtherFee { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}
