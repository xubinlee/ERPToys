using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class MainMenuConstants
    {
        /// <summary>
        /// 公司资料（指客户）
        /// </summary>
        public const string Company = "Company";
        /// <summary>
        /// 客户资料
        /// </summary>
        public const string Customer = "Customer";
        /// <summary>
        /// 部门资料
        /// </summary>
        public const string Department = "Department";
        /// <summary>
        /// 供应商资料
        /// </summary>
        public const string Supplier = "Supplier";
        /// <summary>
        /// 厂家资料
        /// </summary>
        public const string Mfrs = "Mfrs";
        /// <summary>
        /// 职工资料
        /// </summary>
        public const string Staff = "Staff";
        /// <summary>
        /// 成品资料
        /// </summary>
        public const string Goods = "Goods";
        /// <summary>
        /// 材料资料
        /// </summary>
        public const string Material = "Material";
        /// <summary>
        /// 货品类型
        /// </summary>
        public const string GoodsType = "GoodsType";
        /// <summary>
        /// 包装方式
        /// </summary>
        public const string Packaging = "Packaging";
        /// <summary>
        /// 成品布产单
        /// </summary>
        public const string ProductionOrder = "ProductionOrder";
        /// <summary>
        /// 成品布产单查询
        /// </summary>
        public const string ProductionOrderQuery = "ProductionOrderQuery";
        /// <summary>
        /// 成品入库单
        /// </summary>
        public const string ProductionStockInBill = "ProductionStockInBill";
        /// <summary>
        /// 成品入库单查询
        /// </summary>
        public const string ProductionStockInBillQuery = "ProductionStockInBillQuery";
        /// <summary>
        /// 销售退货单
        /// </summary>
        public const string SalesReturnBill = "SalesReturnBill";
        /// <summary>
        /// 销售退货单查询
        /// </summary>
        public const string SalesReturnBillQuery = "SalesReturnBillQuery";
        /// <summary>
        /// 外加工产品回收单
        /// </summary>
        public const string FGStockInBill = "FGStockInBill";
        /// <summary>
        /// 外加工产品回收单查询
        /// </summary>
        public const string FGStockInBillQuery = "FGStockInBillQuery";
        /// <summary>
        /// 外加工退料单
        /// </summary>
        public const string EMSReturnBill = "EMSReturnBill";
        /// <summary>
        /// 外加工退料单查询
        /// </summary>
        public const string EMSReturnBillQuery = "EMSReturnBillQuery";
        /// <summary>
        /// 外加工残次品退货单
        /// </summary>
        public const string EMSDPReturnBill = "EMSDPReturnBill";
        /// <summary>
        /// 外加工残次品退货单查询
        /// </summary>
        public const string EMSDPReturnBillQuery = "EMSDPReturnBillQuery";
        /// <summary>
        /// 采购入料单
        /// </summary>
        public const string SFGStockInBill = "SFGStockInBill";
        /// <summary>
        /// 采购入料单
        /// </summary>
        public const string SFGStockInBillQuery = "SFGStockInBillQuery";
        /// <summary>
        /// 自动机回收单
        /// </summary>
        public const string FSMStockInBill = "FSMStockInBill";
        /// <summary>
        /// 自动机回收单查询
        /// </summary>
        public const string FSMStockInBillQuery = "FSMStockInBillQuery";
        /// <summary>
        /// 入库单查询
        /// </summary>
        //public const string StockInBillQuery = "StockInBillQuery";
        /// <summary>
        /// 订货单
        /// </summary>
        public const string Order = "Order";
        /// <summary>
        /// 订货单查询
        /// </summary>
        public const string OrderQuery = "OrderQuery";
        /// <summary>
        /// 发货单
        /// </summary>
        public const string FGStockOutBill = "FGStockOutBill";
        /// <summary>
        /// 发货单查询
        /// </summary>
        public const string FGStockOutBillQuery = "FGStockOutBillQuery";
        /// <summary>
        /// 投料单
        /// </summary>
        public const string EMSStockOutBill = "EMSStockOutBill";
        /// <summary>
        /// 投料查询
        /// </summary>
        public const string EMSStockOutBillQuery = "EMSStockOutBillQuery";
        /// <summary>
        /// 采购退料单
        /// </summary>
        public const string SFGStockOutBill = "SFGStockOutBill";
        /// <summary>
        /// 采购退料单查询
        /// </summary>
        public const string SFGStockOutBillQuery = "SFGStockOutBillQuery";
        /// <summary>
        /// 自动机发料单
        /// </summary>
        public const string FSMStockOutBill = "FSMStockOutBill";
        /// <summary>
        /// 领料出库单
        /// </summary>
        public const string GetMaterialBill = "GetMaterialBill";
        /// <summary>
        /// 自动机发料单查询
        /// </summary>
        public const string FSMStockOutBillQuery = "FSMStockOutBillQuery";
        /// <summary>
        /// 领料出库单查询
        /// </summary>
        public const string GetMaterialBillQuery = "GetMaterialBillQuery";
        /// <summary>
        /// 自动机退料单
        /// </summary>
        public const string FSMReturnBill = "FSMReturnBill";
        /// <summary>
        /// 自动机退料单查询
        /// </summary>
        public const string FSMReturnBillQuery = "FSMReturnBillQuery";
        /// <summary>
        /// 自动机残次材料退货单
        /// </summary>
        public const string FSMDPReturnBill = "FSMDPReturnBill";
        /// <summary>
        /// 自动机残次材料退货单查询
        /// </summary>
        public const string FSMDPReturnBillQuery = "FSMDPReturnBillQuery";
        /// <summary>
        /// 装配入库单
        /// </summary>
        public const string AssembleStockInBill = "AssembleStockInBill";
        /// <summary>
        /// 退料入库单
        /// </summary>
        public const string ReturnedMaterialBill = "ReturnedMaterialBill";
        /// <summary>
        /// 装配入库单查询
        /// </summary>
        public const string AssembleStockInBillQuery = "AssembleStockInBillQuery";
        /// <summary>
        /// 退料入库单查询
        /// </summary>
        public const string ReturnedMaterialBillQuery = "ReturnedMaterialBillQuery";
        /// <summary>
        /// 自动机生产订单
        /// </summary>
        public const string FSMOrder = "FSMOrder";
        /// <summary>
        /// 自动机生产订单查询
        /// </summary>
        public const string FSMOrderQuery = "FSMOrderQuery";
        /// <summary>
        /// 成品库存明细
        /// </summary>
        public const string InventoryQuery = "InventoryQuery";
        /// <summary>
        /// 成品库存查询
        /// </summary>
        public const string InventoryGroupByGoodsQuery = "InventoryGroupByGoodsQuery";
        /// <summary>
        /// 半成品库存明细
        /// </summary>
        public const string MaterialInventoryQuery = "MaterialInventoryQuery";
        /// <summary>
        /// 半成品库存查询
        /// </summary>
        public const string InventoryGroupByMaterialQuery = "InventoryGroupByMaterialQuery";
        /// <summary>
        /// 外加工库存查询
        /// </summary>
        public const string EMSInventoryQuery = "EMSInventoryQuery";
        /// <summary>
        /// 自动机库存查询
        /// </summary>
        public const string FSMInventoryQuery = "FSMInventoryQuery";
        /// <summary>
        /// 账页查询
        /// </summary>
        public const string AccountBookQuery = "AccountBookQuery";
        /// <summary>
        /// 库存盘点
        /// </summary>
        public const string Stocktaking = "Stocktaking";
        /// <summary>
        /// 盘点盈亏表
        /// </summary>
        public const string ProfitAndLoss = "ProfitAndLoss";
        /// <summary>
        /// 货品装配物料清单
        /// </summary>
        public const string BOM = "BOM";
        /// <summary>
        /// 自动机模具清单
        /// </summary>
        public const string MoldList = "MoldList";
        /// <summary>
        /// 自动机模具原料清单
        /// </summary>
        public const string MoldMaterial = "MoldMaterial";
        /// <summary>
        /// 材料装配物料清单
        /// </summary>
        public const string Assemble = "Assemble";
        /// <summary>
        /// 自动机模具分配
        /// </summary>
        public const string MoldAllot = "MoldAllot";
        /// <summary>
        /// 客户商品售价
        /// </summary>
        public const string CustomerSLSalePrice = "CustomerSLSalePrice";
        /// <summary>
        /// 供应商商品售价
        /// </summary>
        public const string SupplierSLSalePrice = "SupplierSLSalePrice";
        /// <summary>
        /// 收款单
        /// </summary>
        public const string ReceiptBill = "ReceiptBill";
        /// <summary>
        /// 收款单查询
        /// </summary>
        public const string ReceiptBillQuery = "ReceiptBillQuery";
        /// <summary>
        /// 客户结算对账单
        /// </summary>
        public const string StatementOfAccountToCustomer = "StatementOfAccountToCustomer";
        /// <summary>
        /// 付款单
        /// </summary>
        public const string PaymentBill = "PaymentBill";
        /// <summary>
        /// 付款单查询
        /// </summary>
        public const string PaymentBillQuery = "PaymentBillQuery";
        /// <summary>
        /// 供应商结算对账单
        /// </summary>
        public const string StatementOfAccountToSupplier = "StatementOfAccountToSupplier";
        /// <summary>
        /// 外加工货品跟踪日报表
        /// </summary>
        public const string EMSGoodsTrackingDailyReport = "EMSGoodsTrackingDailyReport";
        /// <summary>
        /// 自动机货品跟踪日报表
        /// </summary>
        public const string FSMGoodsTrackingDailyReport = "FSMGoodsTrackingDailyReport";
        /// <summary>
        /// 样品发放情况
        /// </summary>
        public const string SampleStockOutReport = "SampleStockOutReport";
        /// <summary>
        /// 销售单据汇总表
        /// </summary>
        public const string SalesBillSummaryReport = "SalesBillSummaryReport";
        /// <summary>
        /// 客户销售汇总表
        /// </summary>
        public const string SalesSummaryByCustomerReport = "SalesSummaryByCustomerReport";
        /// <summary>
        /// 客户销售汇总月度图表
        /// </summary>
        public const string SalesSummaryMonthlyReport = "SalesSummaryMonthlyReport";
        /// <summary>
        /// 客户销售汇总图表
        /// </summary>
        public const string AnnualSalesSummaryByCustomerReport = "AnnualSalesSummaryByCustomerReport";
        /// <summary>
        /// 商品销售汇总表
        /// </summary>
        public const string SalesSummaryByGoodsReport = "SalesSummaryByGoodsReport";
        /// <summary>
        /// 商品价格销量统计表
        /// </summary>
        public const string SalesSummaryByGoodsPriceReport = "SalesSummaryByGoodsPriceReport";
        /// <summary>
        /// 商品销售汇总图表
        /// </summary>
        public const string AnnualSalesSummaryByGoodsReport = "AnnualSalesSummaryByGoodsReport";
        /// <summary>
        /// 客户商品销售汇总表
        /// </summary>
        public const string GoodsSalesSummaryByCustomerReport = "GoodsSalesSummaryByCustomerReport";
        /// <summary>
        /// 入库单类型
        /// </summary>
        public const string StockInBillType = "StockInBillType";
        /// <summary>
        /// 出库单类型
        /// </summary>
        public const string StockOutBillType = "StockOutBillType";
        /// <summary>
        /// 订货单类型
        /// </summary>
        public const string OrderType = "OrderType";
        /// <summary>
        /// 提醒列表
        /// </summary>
        public const string AlertQuery = "AlertQuery";
        /// <summary>
        /// 权限设置
        /// </summary>
        public const string PermissionSetting = "PermissionSetting";
        /// <summary>
        /// 关于
        /// </summary>
        public const string AboutBox = "AboutBox";
        /// <summary>
        /// 出勤记录
        /// </summary>
        public const string AttGeneralLog = "AttGeneralLog";
        /// <summary>
        /// 人员考勤
        /// </summary>
        public const string StaffAttendance = "StaffAttendance";
        /// <summary>
        /// 考勤明细
        /// </summary>
        public const string AttendanceQuery = "AttendanceQuery";
        /// <summary>
        /// 班次时段设置
        /// </summary>
        public const string SchClass = "SchClass";
        /// <summary>
        /// 人员排班
        /// </summary>
        public const string StaffSchClass = "StaffSchClass";
        /// <summary>
        /// 生产排程
        /// </summary>
        public const string ProductionScheduling = "ProductionScheduling";
        /// <summary>
        /// 日程安排查询
        /// </summary>
        public const string SchedulingQuery = "SchedulingQuery";
        /// <summary>
        /// 工资结算表
        /// </summary>
        public const string WageBill = "WageBill";
        /// <summary>
        /// 工资结算表查询
        /// </summary>
        public const string WageBillQuery = "WageBillQuery";
        /// <summary>
        /// 考勤工资结算表
        /// </summary>
        public const string AttWageBill = "AttWageBill";
        /// <summary>
        /// 考勤工资结算表查询
        /// </summary>
        public const string AttWageBillQuery = "AttWageBillQuery";


        /// <summary>
        /// 客户择样
        /// </summary>
        public const string CustomerSamplePick = "CustomerSamplePick";
        /// <summary>
        /// 择样记录
        /// </summary>
        public const string SamplePickQuery = "SamplePickQuery";
        /// <summary>
        /// 样品扫描
        /// </summary>
        public const string SampleScan = "SampleScan";
    }

    /// <summary>
    /// 数据列常量
    /// </summary>
    public class ColumnsConstants
    {
        /// <summary>
        /// 箱数
        /// </summary>
        public const string Qty = "箱数";
        /// <summary>
        /// 总数量
        /// </summary>
        public const string TotalQty = "总数量";
        /// <summary>
        /// 金额
        /// </summary>
        public const string ATM = "金额";
        /// <summary>
        /// 去税金额
        /// </summary>
        public const string ATMNoTax = "去税金额";
        /// <summary>
        /// 入库数量
        /// </summary>
        public const string InQty = "入库数量";
        /// <summary>
        /// 入库金额
        /// </summary>
        public const string InAMT = "入库金额";
        /// <summary>
        /// 出库数量
        /// </summary>
        public const string OutQty = "出库数量";
        /// <summary>
        /// 出库金额
        /// </summary>
        public const string OutATM = "出库金额";
        /// <summary>
        /// 应收成品数量
        /// </summary>
        public const string 应收成品数量 = "应收成品数量";
        /// <summary>
        /// 本日发料数量
        /// </summary>
        public const string 本日发料数量 = "本日发料数量";
        /// <summary>
        /// 本日交货数量
        /// </summary>
        public const string 本日交货数量 = "本日交货数量";
        /// <summary>
        /// 已用物料数量
        /// </summary>
        public const string 已用物料数量 = "已用物料数量";
        /// <summary>
        /// 本日退料数量
        /// </summary>
        public const string 本日退料数量 = "本日退料数量";
        /// <summary>
        /// 未收成品数量
        /// </summary>
        public const string 未收成品数量 = "未收成品数量";
        /// <summary>
        /// 厂商存料数量
        /// </summary>
        public const string 厂商存料数量 = "厂商存料数量";
    }

    public class ItemDetailStyleConstants
    {
        /// <summary>
        /// 数据查询页面
        /// </summary>
        public const string DataQueryPage = "DataQueryPage";

        /// <summary>
        /// 单据录入页面
        /// </summary>
        public const string BillEditPage = "BillEditPage";
    }

    public class WarehouseConstants
    {
        /// <summary>
        /// 成品仓
        /// </summary>
        public const string FG = "FG";

        /// <summary>
        /// 半成品仓
        /// </summary>
        public const string SFG = "SFG";

        /// <summary>
        /// 外加工
        /// </summary>
        public const string EMS = "EMS";

        /// <summary>
        /// 自动机
        /// </summary>
        public const string FSM = "FSM";
    }

    public class TypesListConstants
    {
        #region 入库单

        
        /// <summary>
        /// 入库单类型
        /// </summary>
        public const string StockInBillType = "StockInBillType";
        ///// <summary>
        ///// 生产入库
        ///// </summary>
        //public const string ProductionStockInBill = "ProductionStockInBill";
        ///// <summary>
        ///// 销售退货
        ///// </summary>
        //public const string SalesReturnBill = "SalesReturnBill";
        ///// <summary>
        ///// 外加工成品回收
        ///// </summary>
        //public const string FGStockInBill = "FGStockInBill";
        ///// <summary>
        ///// 外加工退料
        ///// </summary>
        //public const string EMSReturnBill = "EMSReturnBill";
        ///// <summary>
        ///// 自动机退料
        ///// </summary>
        //public const string FSMReturnBill = "FSMReturnBill";
        ///// <summary>
        ///// 物料入库(采购入料)
        ///// </summary>
        //public const string SFGStockInBill = "SFGStockInBill";
        ///// <summary>
        ///// 自动机物料入库
        ///// </summary>
        //public const string FSMStockInBill = "FSMStockInBill";

        #endregion

        #region 出库单

        /// <summary>
        /// 订单类型
        /// </summary>
        public const string OrderType = "OrderType";
        /// <summary>
        /// 出库单类型
        /// </summary>
        public const string StockOutBillType = "StockOutBillType";
        ///// <summary>
        ///// 成品发货
        ///// </summary>
        //public const string FGStockOutBill = "FGStockOutBill";

        ///// <summary>
        ///// 外加工投料
        ///// </summary>
        //public const string EMSStockOutBill = "EMSStockOutBill";

        ///// <summary>
        ///// 物料出库
        ///// </summary>
        //public const string SFGStockOutBill = "SFGStockOutBill";
        ///// <summary>
        ///// 自动机物料出库
        ///// </summary>
        //public const string FSMStockOutBill = "FSMStockOutBill";


        #endregion

        /// <summary>
        /// 收款类型
        /// </summary>
        public const string ReceiptBillType = "ReceiptBillType";
        /// <summary>
        /// 销售收款
        /// </summary>
        public const string SalesReceipt = "SalesReceipt";
        /// <summary>
        /// 采购退货收款
        /// </summary>
        public const string PurchaseReturnReceipt = "PurchaseReturnReceipt";
        /// <summary>
        /// 付款类型
        /// </summary>
        public const string PaymentBillType = "PaymentBillType";
        /// <summary>
        /// 销售退货付款
        /// </summary>
        public const string SalesReturnPayment = "SalesReturnPayment";
        /// <summary>
        /// 外加工付款
        /// </summary>
        public const string EMSPayment = "EMSPayment";
        /// <summary>
        /// 采购付款
        /// </summary>
        public const string PurchasePayment = "PurchasePayment";
        /// <summary>
        /// 自动机付款
        /// </summary>
        public const string FSMPayment = "FSMPayment";
        /// <summary>
        /// 结算方式
        /// </summary>
        public const string POClearType = "POClearType";
        /// <summary>
        /// 客户类型
        /// </summary>
        public const string CustomerType = "CustomerType";
        /// <summary>
        /// 供应商类型
        /// </summary>
        public const string SupplierType = "SupplierType";
        /// <summary>
        /// 货品类型
        /// </summary>
        public const string GoodsType = "GoodsType";
        /// <summary>
        /// 特权类型
        /// </summary>
        public const string PrivilegeType = "PrivilegeType";
        /// <summary>
        /// 验证方式类型
        /// </summary>
        public const string VerifyMethodType = "VerifyMethodType";
        /// <summary>
        /// 工资类型
        /// </summary>
        public const string WageType = "WageType";
    }
}
