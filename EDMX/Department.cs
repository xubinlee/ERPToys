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
    
    public partial class Department
    {
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public string Code { get; set; }
    	[DataMember]
        public string Name { get; set; }
    	[DataMember]
        public string Contacts { get; set; }
    	[DataMember]
        public string ContactTel { get; set; }
    	[DataMember]
        public string ContactCellPhone { get; set; }
    	[DataMember]
        public string QQ { get; set; }
    	[DataMember]
        public string Fax { get; set; }
    	[DataMember]
        public int Type { get; set; }
    	[DataMember]
        public int Status { get; set; }
    	[DataMember]
        public System.DateTime AddTime { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> UpdateTime { get; set; }
    	[DataMember]
        public string Remark { get; set; }
    }
}
