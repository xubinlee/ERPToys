namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SalesSummaryByGoodsPriceReport")]
    public partial class SalesSummaryByGoodsPriceReport
    {
        [StringLength(20)]
        public string 货号 { get; set; }

        [StringLength(50)]
        public string 品名 { get; set; }

        [Key]
        public decimal 单价 { get; set; }

        public decimal? 箱数 { get; set; }

        public decimal? 总数量 { get; set; }

        public decimal? 重量 { get; set; }

        [StringLength(10)]
        public string 单位 { get; set; }

        public decimal? 金额 { get; set; }
    }
}
