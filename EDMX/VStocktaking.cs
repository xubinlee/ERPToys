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
    using System.Collections.Generic;
    
    public partial class VStocktaking
    {
        public System.Guid WarehouseID { get; set; }
        public System.Guid GoodsID { get; set; }
        public Nullable<System.Guid> SupplierID { get; set; }
        public string 盘点仓库 { get; set; }
        public int 仓库类型 { get; set; }
        public string 盘点厂商 { get; set; }
        public int 货品大类 { get; set; }
        public string 货号 { get; set; }
        public string 品名 { get; set; }
        public decimal 盘点数量 { get; set; }
        public int 装箱数 { get; set; }
        public string 外箱规格 { get; set; }
        public int 内盒 { get; set; }
        public decimal 单价 { get; set; }
        public string 盘点人 { get; set; }
        public System.DateTime 盘点日期 { get; set; }
    }
}