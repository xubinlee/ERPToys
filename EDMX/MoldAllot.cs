namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MoldAllot")]
    public partial class MoldAllot
    {
        [Key]
        [Column(Order = 0)]
        public Guid SupplierID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid GoodsID { get; set; }

        public decimal Qty { get; set; }

        public int PCS { get; set; }

        public int InnerBox { get; set; }

        public decimal Price { get; set; }

        public decimal PriceNoTax { get; set; }
    }
}
