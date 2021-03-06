//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EDMX
{
    using System;
    using System.Runtime.Serialization;
    using System.Collections.Generic;
    
    [DataContract(IsReference = true)]
    [KnownType(typeof(GoodsType))]
    
    public partial class Goods
    {
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public string Code { get; set; }
    	[DataMember]
        public string Name { get; set; }
    	[DataMember]
        public System.Guid GoodsTypeID { get; set; }
    	[DataMember]
        public System.Guid PackagingID { get; set; }
    	[DataMember]
        public Nullable<System.Guid> CustomerID { get; set; }
    	[DataMember]
        public string Material { get; set; }
    	[DataMember]
        public Nullable<decimal> Dosage { get; set; }
    	[DataMember]
        public Nullable<decimal> Subpackage { get; set; }
    	[DataMember]
        public string Unit { get; set; }
    	[DataMember]
        public string SPEC { get; set; }
    	[DataMember]
        public string MEAS { get; set; }
    	[DataMember]
        public Nullable<decimal> PurchasePrice { get; set; }
    	[DataMember]
        public decimal Price { get; set; }
    	[DataMember]
        public decimal PriceNoTax { get; set; }
    	[DataMember]
        public string BarCode { get; set; }
    	[DataMember]
        public decimal Volume { get; set; }
    	[DataMember]
        public decimal GWeight { get; set; }
    	[DataMember]
        public decimal NWeight { get; set; }
    	[DataMember]
        public Nullable<decimal> Cycle { get; set; }
    	[DataMember]
        public int PCS { get; set; }
    	[DataMember]
        public int InnerBox { get; set; }
    	[DataMember]
        public decimal InPutVAT { get; set; }
    	[DataMember]
        public decimal OutPutVAT { get; set; }
    	[DataMember]
        public decimal UpperLimit { get; set; }
    	[DataMember]
        public decimal LowerLimit { get; set; }
    	[DataMember]
        public byte[] Pic { get; set; }
    	[DataMember]
        public int Type { get; set; }
    	[DataMember]
        public int Status { get; set; }
    	[DataMember]
        public System.DateTime AddTime { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> UpdateTime { get; set; }
    	[DataMember]
        public string MainMark { get; set; }
    	[DataMember]
        public string SideMark { get; set; }
    	[DataMember]
        public string InnerMark { get; set; }
    	[DataMember]
        public decimal CavityNumber { get; set; }
    	[DataMember]
        public string Toner { get; set; }
    	[DataMember]
        public string Remark { get; set; }
    	[DataMember]
        public bool IsStop { get; set; }
    	[DataMember]
        public Nullable<int> Source { get; set; }
    	[DataMember]
        public decimal Subsidy { get; set; }
    	[DataMember]
        public Nullable<int> PlanYield { get; set; }
    
    	[DataMember]
        public virtual GoodsType GoodsType { get; set; }
    }
}
