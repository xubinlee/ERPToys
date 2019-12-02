namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReceiptBillDtl")]
    public partial class ReceiptBillDtl
    {
        public Guid ID { get; set; }

        public Guid HdID { get; set; }

        public Guid BillID { get; set; }

        public decimal BillAMT { get; set; }

        public decimal ReceiptedAMT { get; set; }

        public decimal UnReceiptedAMT { get; set; }

        public decimal LastReceiptedAMT { get; set; }
    }
}
