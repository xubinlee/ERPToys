namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Goods
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Goods()
        {
            OrderDtl = new HashSet<OrderDtl>();
        }

        public Guid ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public Guid GoodsTypeID { get; set; }

        public Guid PackagingID { get; set; }

        public Guid? CustomerID { get; set; }

        [StringLength(20)]
        public string Material { get; set; }

        public decimal? Dosage { get; set; }

        public decimal? Subpackage { get; set; }

        [StringLength(10)]
        public string Unit { get; set; }

        [StringLength(20)]
        public string SPEC { get; set; }

        [StringLength(20)]
        public string MEAS { get; set; }

        public decimal? PurchasePrice { get; set; }

        public decimal Price { get; set; }

        public decimal PriceNoTax { get; set; }

        [StringLength(30)]
        public string BarCode { get; set; }

        public decimal Volume { get; set; }

        public decimal GWeight { get; set; }

        public decimal NWeight { get; set; }

        public decimal? Cycle { get; set; }

        public int PCS { get; set; }

        public int InnerBox { get; set; }

        public decimal InPutVAT { get; set; }

        public decimal OutPutVAT { get; set; }

        public decimal UpperLimit { get; set; }

        public decimal LowerLimit { get; set; }

        [Column(TypeName = "image")]
        public byte[] Pic { get; set; }

        public int Type { get; set; }

        public int Status { get; set; }

        public DateTime AddTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        [Column(TypeName = "ntext")]
        public string MainMark { get; set; }

        [Column(TypeName = "ntext")]
        public string SideMark { get; set; }

        [Column(TypeName = "ntext")]
        public string InnerMark { get; set; }

        public decimal CavityNumber { get; set; }

        [StringLength(20)]
        public string Toner { get; set; }

        [Column(TypeName = "ntext")]
        public string Remark { get; set; }

        public bool IsStop { get; set; }

        public int? Source { get; set; }

        public decimal Subsidy { get; set; }

        public int? PlanYield { get; set; }

        public virtual GoodsType GoodsType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDtl> OrderDtl { get; set; }
    }
}
