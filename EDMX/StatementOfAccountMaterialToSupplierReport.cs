namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StatementOfAccountMaterialToSupplierReport")]
    public partial class StatementOfAccountMaterialToSupplierReport
    {
        [Key]
        public Guid CompanyID { get; set; }

        [StringLength(30)]
        public string 料名 { get; set; }

        public decimal? 上期存料 { get; set; }

        public decimal? 本期去料 { get; set; }

        public decimal? 存料合计 { get; set; }

        public decimal? 生产用料 { get; set; }

        public decimal? 损耗 { get; set; }

        public decimal? 用料合计 { get; set; }

        public decimal? 结存 { get; set; }
    }
}
