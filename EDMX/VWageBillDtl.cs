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
    
    public partial class VWageBillDtl
    {
    	[DataMember]
        public Nullable<System.Guid> UserID { get; set; }
    	[DataMember]
        public string YearMonth { get; set; }
    	[DataMember]
        public Nullable<decimal> Wages { get; set; }
    	[DataMember]
        public Nullable<decimal> Welfare { get; set; }
    	[DataMember]
        public Nullable<decimal> Deduction { get; set; }
    	[DataMember]
        public Nullable<decimal> SocialSecurity { get; set; }
    	[DataMember]
        public Nullable<decimal> IndividualIncomeTax { get; set; }
    	[DataMember]
        public Nullable<decimal> AMT { get; set; }
    	[DataMember]
        public int WageStatus { get; set; }
    }
}
