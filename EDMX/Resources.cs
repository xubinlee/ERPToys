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
    
    public partial class Resources
    {
    	[DataMember]
        public int UniqueID { get; set; }
    	[DataMember]
        public Nullable<int> ResourceID { get; set; }
    	[DataMember]
        public string ResourceName { get; set; }
    	[DataMember]
        public Nullable<int> Color { get; set; }
    	[DataMember]
        public byte[] Image { get; set; }
    	[DataMember]
        public string CustomField1 { get; set; }
    }
}
