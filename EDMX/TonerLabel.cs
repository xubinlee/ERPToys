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
    
    public partial class TonerLabel
    {
    	[DataMember]
        public string Customer { get; set; }
    	[DataMember]
        public string Goods { get; set; }
    	[DataMember]
        public string Material { get; set; }
    	[DataMember]
        public Nullable<decimal> Dosage { get; set; }
    	[DataMember]
        public Nullable<decimal> Subpackage { get; set; }
    	[DataMember]
        public Nullable<decimal> TotalQty { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> DATE { get; set; }
    }
}
