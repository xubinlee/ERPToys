namespace EDMX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StaffSchClass")]
    public partial class StaffSchClass
    {
        public Guid ID { get; set; }

        public Guid DeptID { get; set; }

        public Guid SchClassID { get; set; }

        public int SchSerialNo { get; set; }
    }
}
