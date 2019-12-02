namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PaymentBillDtl")]
    public partial class PaymentBillDtl
    {
        public Guid ID { get; set; }

        public Guid HdID { get; set; }

        public Guid BillID { get; set; }

        public decimal BillAMT { get; set; }

        public decimal PaidAMT { get; set; }

        public decimal UnPaidAMT { get; set; }

        public decimal LastPaidAMT { get; set; }
    }
}
