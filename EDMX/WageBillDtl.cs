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
    [KnownType(typeof(WageBillHd))]
    
    public partial class WageBillDtl
    {
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public System.Guid HdID { get; set; }
    	[DataMember]
        public string YearMonth { get; set; }
    	[DataMember]
        public decimal Wages { get; set; }
    	[DataMember]
        public decimal Welfare { get; set; }
    	[DataMember]
        public decimal Deduction { get; set; }
    	[DataMember]
        public decimal SocialSecurity { get; set; }
    	[DataMember]
        public decimal IndividualIncomeTax { get; set; }
    	[DataMember]
        public decimal AMT { get; set; }
    
    	//[DataMember]
        public virtual WageBillHd WageBillHd { get; set; }
    }
}
