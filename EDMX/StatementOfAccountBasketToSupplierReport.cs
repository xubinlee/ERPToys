namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StatementOfAccountBasketToSupplierReport")]
    public partial class StatementOfAccountBasketToSupplierReport
    {
        [Key]
        public Guid CompanyID { get; set; }

        [StringLength(30)]
        public string 筐类 { get; set; }

        public int? 上期欠筐 { get; set; }

        public int? 本期去筐 { get; set; }

        public int? 本期来筐 { get; set; }

        public int? 共欠 { get; set; }
    }
}
