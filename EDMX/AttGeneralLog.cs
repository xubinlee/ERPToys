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
    
    public partial class AttGeneralLog
    {
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public string EnrollNumber { get; set; }
    	[DataMember]
        public int VerifyMode { get; set; }
    	[DataMember]
        public int InOutMode { get; set; }
    	[DataMember]
        public System.DateTime AttTime { get; set; }
    	[DataMember]
        public int Workcode { get; set; }
    	[DataMember]
        public bool AttFlag { get; set; }
    	[DataMember]
        public int AttStatus { get; set; }
    	[DataMember]
        public string Description { get; set; }
    	[DataMember]
        public Nullable<System.Guid> SchClassID { get; set; }
    }
}
