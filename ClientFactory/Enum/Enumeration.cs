using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace ClientFactory
{
    public enum MainMenuEnum
    {
        /// <summary>
        /// 仓库资料
        /// </summary>
        Warehouse,
        /// <summary>
        /// 公司资料（指客户）
        /// </summary>
        Company,
        /// <summary>
        /// 客户资料
        /// </summary>
        Customer,
        /// <summary>
        /// 部门资料
        /// </summary>
        Department,
        /// <summary>
        /// 供应商资料
        /// </summary>
        Supplier,
        /// <summary>
        /// 厂家资料
        /// </summary>
        Mfrs,
        /// <summary>
        /// 职工资料
        /// </summary>
        UsersInfo,
        /// <summary>
        /// 成品资料
        /// </summary>
        Goods,
        /// <summary>
        /// 材料资料
        /// </summary>
        Material,
        /// <summary>
        /// 货品类型
        /// </summary>
        GoodsType,
        /// <summary>
        /// 包装方式
        /// </summary>
        Packaging,
        /// <summary>
        /// 成品布产单
        /// </summary>
        ProductionOrder,
        /// <summary>
        /// 成品布产单查询
        /// </summary>
        ProductionOrderQuery,
        /// <summary>
        /// 成品入库单
        /// </summary>
        ProductionStockInBill,
        /// <summary>
        /// 成品入库单查询
        /// </summary>
        ProductionStockInBillQuery,
        /// <summary>
        /// 销售退货单
        /// </summary>
        SalesReturnBill,
        /// <summary>
        /// 销售退货单查询
        /// </summary>
        SalesReturnBillQuery,
        /// <summary>
        /// 外加工产品回收单
        /// </summary>
        FGStockInBill,
        /// <summary>
        /// 外加工产品回收单查询
        /// </summary>
        FGStockInBillQuery,
        /// <summary>
        /// 外加工退料单
        /// </summary>
        EMSReturnBill,
        /// <summary>
        /// 外加工退料单查询
        /// </summary>
        EMSReturnBillQuery,
        /// <summary>
        /// 外加工残次品退货单
        /// </summary>
        EMSDPReturnBill,
        /// <summary>
        /// 外加工残次品退货单查询
        /// </summary>
        EMSDPReturnBillQuery,
        /// <summary>
        /// 采购入料单
        /// </summary>
        SFGStockInBill,
        /// <summary>
        /// 采购入料单
        /// </summary>
        SFGStockInBillQuery,
        /// <summary>
        /// 自动机回收单
        /// </summary>
        FSMStockInBill,
        /// <summary>
        /// 自动机回收单查询
        /// </summary>
        FSMStockInBillQuery,
        /// <summary>
        /// 入库单查询
        /// </summary>
        //StockInBillQuery,
        /// <summary>
        /// 订货单
        /// </summary>
        Order,
        /// <summary>
        /// 订货单查询
        /// </summary>
        OrderQuery,
        /// <summary>
        /// 发货单
        /// </summary>
        FGStockOutBill,
        /// <summary>
        /// 发货单查询
        /// </summary>
        FGStockOutBillQuery,
        /// <summary>
        /// 投料单
        /// </summary>
        EMSStockOutBill,
        /// <summary>
        /// 投料查询
        /// </summary>
        EMSStockOutBillQuery,
        /// <summary>
        /// 采购退料单
        /// </summary>
        SFGStockOutBill,
        /// <summary>
        /// 采购退料单查询
        /// </summary>
        SFGStockOutBillQuery,
        /// <summary>
        /// 自动机发料单
        /// </summary>
        FSMStockOutBill,
        /// <summary>
        /// 领料出库单
        /// </summary>
        GetMaterialBill,
        /// <summary>
        /// 自动机发料单查询
        /// </summary>
        FSMStockOutBillQuery,
        /// <summary>
        /// 领料出库单查询
        /// </summary>
        GetMaterialBillQuery,
        /// <summary>
        /// 自动机退料单
        /// </summary>
        FSMReturnBill,
        /// <summary>
        /// 自动机退料单查询
        /// </summary>
        FSMReturnBillQuery,
        /// <summary>
        /// 自动机残次材料退货单
        /// </summary>
        FSMDPReturnBill,
        /// <summary>
        /// 自动机残次材料退货单查询
        /// </summary>
        FSMDPReturnBillQuery,
        /// <summary>
        /// 装配入库单
        /// </summary>
        AssembleStockInBill,
        /// <summary>
        /// 退料入库单
        /// </summary>
        ReturnedMaterialBill,
        /// <summary>
        /// 装配入库单查询
        /// </summary>
        AssembleStockInBillQuery,
        /// <summary>
        /// 退料入库单查询
        /// </summary>
        ReturnedMaterialBillQuery,
        /// <summary>
        /// 自动机生产订单
        /// </summary>
        FSMOrder,
        /// <summary>
        /// 自动机生产订单查询
        /// </summary>
        FSMOrderQuery,
        /// <summary>
        /// 成品库存明细
        /// </summary>
        InventoryQuery,
        /// <summary>
        /// 成品库存查询
        /// </summary>
        InventoryGroupByGoodsQuery,
        /// <summary>
        /// 半成品库存明细
        /// </summary>
        MaterialInventoryQuery,
        /// <summary>
        /// 半成品库存查询
        /// </summary>
        InventoryGroupByMaterialQuery,
        /// <summary>
        /// 外加工库存查询
        /// </summary>
        EMSInventoryQuery,
        /// <summary>
        /// 自动机库存查询
        /// </summary>
        FSMInventoryQuery,
        /// <summary>
        /// 账页查询
        /// </summary>
        AccountBookQuery,
        /// <summary>
        /// 账面库存
        /// </summary>
        Inventory,
        /// <summary>
        /// 库存盘点
        /// </summary>
        Stocktaking,
        /// <summary>
        /// 盘点盈亏表
        /// </summary>
        ProfitAndLoss,
        /// <summary>
        /// 未上架商品确认单
        /// </summary>
        UnlistedGoods,
        /// <summary>
        /// 盘点日志表
        /// </summary>
        StocktakingLogHd,
        /// <summary>
        /// 盘点差异日志表
        /// </summary>
        VProfitAndLossLog,
        /// <summary>
        /// 未上架商品日志表
        /// </summary>
        VUnlistedGoodsLog,
        /// <summary>
        /// 货品装配物料清单
        /// </summary>
        BOM,
        /// <summary>
        /// 自动机模具清单
        /// </summary>
        MoldList,
        /// <summary>
        /// 自动机模具原料清单
        /// </summary>
        MoldMaterial,
        /// <summary>
        /// 材料装配物料清单
        /// </summary>
        Assemble,
        /// <summary>
        /// 自动机模具分配
        /// </summary>
        MoldAllot,
        /// <summary>
        /// 客户商品售价
        /// </summary>
        CustomerSLSalePrice,
        /// <summary>
        /// 供应商商品售价
        /// </summary>
        SupplierSLSalePrice,
        /// <summary>
        /// 收款单
        /// </summary>
        ReceiptBill,
        /// <summary>
        /// 收款单查询
        /// </summary>
        ReceiptBillQuery,
        /// <summary>
        /// 客户结算对账单
        /// </summary>
        StatementOfAccountToCustomer,
        /// <summary>
        /// 付款单
        /// </summary>
        PaymentBill,
        /// <summary>
        /// 付款单查询
        /// </summary>
        PaymentBillQuery,
        /// <summary>
        /// 供应商结算对账单
        /// </summary>
        StatementOfAccountToSupplier,
        /// <summary>
        /// 外加工货品跟踪日报表
        /// </summary>
        EMSGoodsTrackingDailyReport,
        /// <summary>
        /// 自动机货品跟踪日报表
        /// </summary>
        FSMGoodsTrackingDailyReport,
        /// <summary>
        /// 样品发放情况
        /// </summary>
        SampleStockOutReport,
        /// <summary>
        /// 销售单据汇总表
        /// </summary>
        SalesBillSummaryReport,
        /// <summary>
        /// 客户销售汇总表
        /// </summary>
        SalesSummaryByCustomerReport,
        /// <summary>
        /// 客户销售汇总月度图表
        /// </summary>
        SalesSummaryMonthlyReport,
        /// <summary>
        /// 客户销售汇总图表
        /// </summary>
        AnnualSalesSummaryByCustomerReport,
        /// <summary>
        /// 商品销售汇总表
        /// </summary>
        SalesSummaryByGoodsReport,
        /// <summary>
        /// 商品价格销量统计表
        /// </summary>
        SalesSummaryByGoodsPriceReport,
        /// <summary>
        /// 商品销售汇总图表
        /// </summary>
        AnnualSalesSummaryByGoodsReport,
        /// <summary>
        /// 客户商品销售汇总表
        /// </summary>
        GoodsSalesSummaryByCustomerReport,
        /// <summary>
        /// 入库单类型
        /// </summary>
        StockInBillType,
        /// <summary>
        /// 出库单类型
        /// </summary>
        StockOutBillType,
        /// <summary>
        /// 订货单类型
        /// </summary>
        OrderType,
        /// <summary>
        /// 提醒列表
        /// </summary>
        AlertQuery,
        /// <summary>
        /// 权限设置
        /// </summary>
        PermissionSetting,
        /// <summary>
        /// 关于
        /// </summary>
        AboutBox,
        /// <summary>
        /// 出勤记录
        /// </summary>
        AttGeneralLog,
        /// <summary>
        /// 人员考勤
        /// </summary>
        StaffAttendance,
        /// <summary>
        /// 考勤明细
        /// </summary>
        AttendanceQuery,
        /// <summary>
        /// 班次时段设置
        /// </summary>
        SchClass,
        /// <summary>
        /// 人员排班
        /// </summary>
        StaffSchClass,
        /// <summary>
        /// 生产排程
        /// </summary>
        ProductionScheduling,
        /// <summary>
        /// 日程安排查询
        /// </summary>
        SchedulingQuery,
        /// <summary>
        /// 工资结算表
        /// </summary>
        WageBill,
        /// <summary>
        /// 工资结算表查询
        /// </summary>
        WageBillQuery,
        /// <summary>
        /// 考勤工资结算表
        /// </summary>
        AttWageBill,
        /// <summary>
        /// 考勤工资结算表查询
        /// </summary>
        AttWageBillQuery,


        /// <summary>
        /// 客户择样
        /// </summary>
        CustomerSamplePick,
        /// <summary>
        /// 择样记录
        /// </summary>
        SamplePickQuery,
        /// <summary>
        /// 样品扫描
        /// </summary>
        SampleScan,

        /// <summary>
        /// 系统状态
        /// </summary>
        SystemStatus,
    }
    /// <summary>
    /// 系统版本
    /// </summary>
    public enum ISnowSoftVersion
    {
        /// <summary>
        /// 所有功能-1
        /// </summary>
        [MemberDescription("所有功能", "ALL")]
        ALL = -1,
        /// <summary>
        /// 采购功能0
        /// </summary>
        [MemberDescription("采购功能", "Procurement")]
        Procurement = 0,
        /// <summary>
        /// 销售功能1
        /// </summary>
        [MemberDescription("销功能", "Sales")]
        Sales = 1,
        /// <summary>
        /// 销售管理（带成品出入库库存）2
        /// </summary>
        [MemberDescription("销售管理", "SalesManagement")]
        SalesManagement = 2,
        /// <summary>
        /// 进销存3
        /// </summary>
        [MemberDescription("原料", "PurchaseSellStock")]
        PurchaseSellStock = 3,
        /// <summary>
        /// 外加工4
        /// </summary>
        [MemberDescription("外加工", "Mold")]
        EMS = 4,
        /// <summary>
        /// 自动机5
        /// </summary>
        [MemberDescription("自动机", "FSM")]
        FSM = 5,
    }

    public enum WarehouseEnum
    {
        /// <summary>
        /// 成品仓
        /// </summary>
        FG,

        /// <summary>
        /// 半成品仓
        /// </summary>
        SFG,

        /// <summary>
        /// 外加工
        /// </summary>
        EMS,

        /// <summary>
        /// 自动机
        /// </summary>
        FSM,
    }

    //public enum TypesEnum
    //{
    //    /// <summary>
    //    /// 客户类型
    //    /// </summary>
    //    CustomerType,
    //    /// <summary>
    //    /// 货品类型
    //    /// </summary>
    //    GoodsType,
    //    /// <summary>
    //    /// 订单类型
    //    /// </summary>
    //    OrderType,
    //    /// <summary>
    //    /// 付款类型
    //    /// </summary>
    //    PaymentBillType,
    //    /// <summary>
    //    /// 结算方式
    //    /// </summary>
    //    POClearType,
    //    /// <summary>
    //    /// 特权类型
    //    /// </summary>
    //    PrivilegeType,
    //    /// <summary>
    //    /// 收款类型
    //    /// </summary>
    //    ReceiptBillType,
    //    /// <summary>
    //    /// 入库单类型
    //    /// </summary>
    //    StockInBillType,
    //    /// <summary>
    //    /// 出库单类型
    //    /// </summary>
    //    StockOutBillType,
    //    /// <summary>
    //    /// 供应商类型
    //    /// </summary>
    //    SupplierType,
    //    /// <summary>
    //    /// 验证方式类型
    //    /// </summary>
    //    VerifyMethodType,
    //    /// <summary>
    //    /// 工资类型
    //    /// </summary>
    //    WageType,
    //}

    /// <summary>
    /// 统计列
    /// </summary>
    public enum SummaryItemColumns
    {
        /// <summary>
        /// 箱数
        /// </summary>
        箱数,
        /// <summary>
        /// 订货箱数
        /// </summary>
        订货箱数,
        /// <summary>
        /// 待发箱数
        /// </summary>
        待发箱数,
        /// <summary>
        /// 可用箱数
        /// </summary>
        可用箱数,
        /// <summary>
        /// 数量
        /// </summary>
        数量,
        /// <summary>
        /// 总数量
        /// </summary>
        总数量,
        /// <summary>
        /// 布产数量
        /// </summary>
        布产数量,
        /// <summary>
        /// 可用数量
        /// </summary>
        可用数量,
        /// <summary>
        /// 金额
        /// </summary>
        金额,
        /// <summary>
        /// 应收金额
        /// </summary>
        应收金额,
        /// <summary>
        /// 实收金额
        /// </summary>
        实收金额,
        /// <summary>
        /// 去税金额
        /// </summary>
        去税金额,
        /// <summary>
        /// 入库数量
        /// </summary>
        入库数量,
        /// <summary>
        /// 入库金额
        /// </summary>
        入库金额,
        /// <summary>
        /// 出库数量
        /// </summary>
        出库数量,
        /// <summary>
        /// 出库金额
        /// </summary>
        出库金额,

        /// <summary>
        /// 品名
        /// </summary>
        品名,
        /// <summary>
        /// 应收货品数量
        /// </summary>
        应收货品数量,
        /// <summary>
        /// 本日发料数量
        /// </summary>
        本日发料数量,
        /// <summary>
        /// 本日交货数量
        /// </summary>
        本日交货数量,
        /// <summary>
        /// 已用物料数量
        /// </summary>
        已用物料数量,
        /// <summary>
        /// 本日退料数量
        /// </summary>
        本日退料数量,
        /// <summary>
        /// 未收货品数量
        /// </summary>
        未收货品数量,
        /// <summary>
        /// 厂商存料数量
        /// </summary>
        厂商存料数量,

        /// <summary>
        /// 单据金额
        /// </summary>
        单据金额,
        /// <summary>
        /// 已收金额
        /// </summary>
        已收金额,
        /// <summary>
        /// 未收金额
        /// </summary>
        未收金额,
        /// <summary>
        /// 本次收款
        /// </summary>
        本次收款,
        /// <summary>
        /// 已付金额
        /// </summary>
        已付金额,
        /// <summary>
        /// 未付金额
        /// </summary>
        未付金额,
        /// <summary>
        /// 本次付款
        /// </summary>
        本次付款,
        /// <summary>
        /// 重量
        /// </summary>
        重量,
        /// <summary>
        /// 重量_斤
        /// </summary>
        重量_斤,
        /// <summary>
        /// 模数
        /// </summary>
        模数,
        /// <summary>
        /// 应产模数
        /// </summary>
        应产模数,
        /// <summary>
        /// 实产模数
        /// </summary>
        实产模数,
        /// <summary>
        /// 当班金额
        /// </summary>
        当班金额,
        /// <summary>
        /// 基本工资
        /// </summary>
        基本工资,
        /// <summary>
        /// 福利
        /// </summary>
        福利,
        /// <summary>
        /// 扣款
        /// </summary>
        扣款,
        /// <summary>
        /// 代扣社保
        /// </summary>
        代扣社保,
        /// <summary>
        /// 代扣个税
        /// </summary>
        代扣个税,
        /// <summary>
        /// 实发工资
        /// </summary>
        实发工资,
        /// <summary>
        /// 迟到分钟数
        /// </summary>
        迟到分钟数,
        /// <summary>
        /// 早退分钟数
        /// </summary>
        早退分钟数,
    }

    /// <summary>
    /// 单据按钮状态
    /// </summary>
    //public enum BillBtnStatus
    //{
    //    /// <summary>
    //    /// 添加
    //    /// </summary>
    //    Add = 0,
    //    /// <summary>
    //    /// 编辑
    //    /// </summary>
    //    Edit = 1,
    //    /// <summary>
    //    /// 保存
    //    /// </summary>
    //    Save = 2,
    //    /// <summary>
    //    /// 审核
    //    /// </summary>
    //    Audit = 3,
    //    /// <summary>
    //    /// 打印
    //    /// </summary>
    //    Print = 4,
    //    /// <summary>
    //    /// 删除
    //    /// </summary>
    //    Delete = 5,
    //}
    public enum StatusEnum
    {
        /// <summary>
        /// 有效
        /// </summary>
        [MemberDescription("有效", "Valid")]
        Valid = 0,
        /// <summary>
        /// 无效
        /// </summary>
        [MemberDescription("无效", "Invalid")]
        Invalid = 1,
    }
    /// <summary>
    /// 单据状态
    /// </summary>
    public enum BillStatus
    {
        /// <summary>
        /// 未审核
        /// </summary>
        [MemberDescription("未审核", "UnAudited")]
        UnAudited = 0,
        /// <summary>
        /// 已审核
        /// </summary>
        [MemberDescription("已审核", "Audited")]
        Audited = 1,
        /// <summary>
        /// 未结清
        /// </summary>
        [MemberDescription("未结清", "UnCleared")]
        UnCleared = 2,
        /// <summary>
        /// 已结账
        /// </summary>
        [MemberDescription("已结账", "Cleared")]
        Cleared = 3,
    }


    /// <summary>
    /// 工资状态
    /// </summary>
    public enum WageStatus
    {
        /// <summary>
        /// 未结算
        /// </summary>
        [MemberDescription("未结算", "UnCleared")]
        UnClosed = 0,
        /// <summary>
        /// 已结算
        /// </summary>
        [MemberDescription("已结算", "Cleared")]
        Closed = 1,
    }

    public enum ButtonType
    {
        /// <summary>
        /// 添加
        /// </summary>
        [MemberDescription("添加", "Add")]
        btnAdd = 0,
        /// <summary>
        /// 修改
        /// </summary>
        [MemberDescription("修改", "Edit")]
        btnEdit = 1,
        /// <summary>
        /// 保存
        /// </summary>
        [MemberDescription("保存", "Save")]
        btnSave = 2,
        /// <summary>
        /// 审核
        /// </summary>
        [MemberDescription("审核", "Audit")]
        btnAudit = 3,
        /// <summary>
        /// 打印
        /// </summary>
        [MemberDescription("打印", "Print")]
        btnPrint = 4,
        /// <summary>
        /// 删除
        /// </summary>
        [MemberDescription("删除", "Del")]
        btnDel = 5,
    }

    /// <summary>
    /// BOM清单类型
    /// </summary>
    public enum BOMType
    {
        /// <summary>
        /// 货品装配BOM0
        /// </summary>
        [MemberDescription("货品装配", "BOM")]
        BOM = 0,
        /// <summary>
        /// 模具BOM1
        /// </summary>
        [MemberDescription("模具清单", "MoldList")]
        MoldList = 1,
        /// <summary>
        /// 模具原料BOM2
        /// </summary>
        [MemberDescription("模具原料", "MoldMaterial")]
        MoldMaterial = 2,
        /// <summary>
        /// 材料装配BOM3
        /// </summary>
        [MemberDescription("材料装配", "Assemble")]
        Assemble = 3,
    }

    /// <summary>
    /// 订单类型
    /// </summary>
    public enum OrderBillType
    {
        /// <summary>
        /// 销售订单
        /// </summary>
        [MemberDescription("销售订单", "Order")]
        Order = 0,
        /// <summary>
        /// 自动机生产订单
        /// </summary>
        [MemberDescription("自动机生产订单", "FSM")]
        FSM = 1,
        /// <summary>
        /// 成品布产单
        /// </summary>
        [MemberDescription("成品布产单", "ProductionOrder")]
        ProductionOrder = 2,
    }
    /// <summary>
    /// 入库单类型
    /// </summary>
    //public enum InStoreBillType
    //{
    //    /// <summary>
    //    /// 成品入库
    //    /// </summary>
    //    FG = 0,
    //    /// <summary>
    //    /// 半成品入库
    //    /// </summary>
    //    SFG = 1,
    //    /// <summary>
    //    /// 退货入库
    //    /// </summary>
    //    Refund = 2,
    //    /// <summary>
    //    /// 补差单入库
    //    /// </summary>
    //    Variance = 3,
    //}

    /// <summary>
    /// 出库单类型
    /// </summary>
    //public enum OutStoreBillType
    //{
    //    /// <summary>
    //    /// 销售发货
    //    /// </summary>
    //    Sales = 0,
    //    /// <summary>
    //    /// 样品发货
    //    /// </summary>
    //    SampleDist = 1,
    //    /// <summary>
    //    /// 半成品出库
    //    /// </summary>
    //    SFG = 2,
    //}
    /// <summary>
    /// 订货单类型
    /// </summary>
    public enum OrderTypeEnum
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 紧急
        /// </summary>
        Emergency = 1,
    }
    /// <summary>
    /// 客户类型
    /// </summary>
    public enum CustomerTypeEnum
    {
        /// <summary>
        /// 内销
        /// </summary>
        [MemberDescription("内销", "DomesticSales")]
        DomesticSales,

        /// <summary>
        /// 外销
        /// </summary>
        [MemberDescription("外销", "ExportSales")]
        ExportSales
    }
    /// <summary>
    /// 供应商类型
    /// </summary>
    public enum SupplierTypeEnum
    {
        /// <summary>
        /// 采购
        /// </summary>
        Purchase = 0,
        /// <summary>
        /// 外加工
        /// </summary>
        EMS = 1,
        /// <summary>
        /// 自动机
        /// </summary>
        FSM = 2,
    }

    /// <summary>
    /// 业务往来类型
    /// </summary>
    public enum BusinessContactType
    {
        /// <summary>
        /// 客户
        /// </summary>
        Customer = 0,
        /// <summary>
        /// 供应商
        /// </summary>
        Supplier = 1,
    }

    /// <summary>
    /// 货品大类
    /// </summary>
    public enum GoodsBigTypeEnum
    {
        /// <summary>
        /// 所有-1
        /// </summary>
        [MemberDescription("所有", "All")]
        All = -1,
        /// <summary>
        /// 成品0
        /// </summary>
        [MemberDescription("成品资料", "Goods")]
        Goods = 0,
        /// <summary>
        /// 包装资料1
        /// </summary>
        [MemberDescription("包装资料", "SFGoods")]
        SFGoods = 1,
        /// <summary>
        /// 装配材料2
        /// </summary>
        [MemberDescription("装配材料", "Stuff")]
        Stuff = 2,
        /// <summary>
        /// 原料3
        /// </summary>
        [MemberDescription("原料资料", "Material")]
        Material = 3,
        /// <summary>
        /// 模具4
        /// </summary>
        [MemberDescription("模具资料", "Mold")]
        Mold = 4,
        /// <summary>
        /// 筐袋5
        /// </summary>
        [MemberDescription("筐袋资料", "Basket")]
        Basket = 5,
    }

    /// <summary>
    /// 收款类型
    /// </summary>
    public enum ReceiptBillTypeEnum
    {
        [MemberDescription("销售收款", "SalesReceipt")]
        SalesReceipt = 0,
        [MemberDescription("销售退货付款", "SalesReturnPayment")]
        SalesReturnPayment = 2,
        [MemberDescription("采购退货收款", "PurchaseReturnReceipt")]
        PurchaseReturnReceipt = 4,
        [MemberDescription("散装销售收款", "SupplierReceipt")]
        SupplierReceipt = 10,

    }

    /// <summary>
    /// 付款类型
    /// </summary>
    public enum PaymentBillTypeEnum
    {
        [MemberDescription("销售退货付款", "SalesReturnPayment")]
        SalesReturnPayment = 2,
        [MemberDescription("外加工付款", "EMSPayment")]
        EMSPayment = 3,
        [MemberDescription("采购退货收款", "PurchaseReturnReceipt")]
        PurchaseReturnReceipt = 4,
        [MemberDescription("采购付款", "PurchasePayment")]
        PurchasePayment = 5,
        [MemberDescription("自动机付款", "FSMPayment")]
        FSMPayment = 6,
        [MemberDescription("装配工资", "AssemblePayment")]
        AssemblePayment = 8,

    }

    public enum POClearTypeEnum
    {
        [MemberDescription("现金", "Cash")]
        Cash,
        [MemberDescription("汇兑", "Exchange")]
        Exchange,
        [MemberDescription("月结", "Net30Days")]
        Net30Days,
        [MemberDescription("三结一", "Net90Days")]
        Net90Days,
    }

    /// <summary>
    /// 入库单类型
    /// </summary>
    public enum StockInBillTypeEnum
    {
        [MemberDescription("生产入库", "ProductionStockInBill")]
        ProductionStockInBill,
        [MemberDescription("补差单入库", "DiffStockInBill")]
        DiffStockInBill,
        [MemberDescription("销售退货", "SalesReturnBill")]
        SalesReturnBill,
        [MemberDescription("外加工回收", "FGStockInBill")]
        FGStockInBill,
        [MemberDescription("外加工退料", "EMSReturnBill")]
        EMSReturnBill,
        [MemberDescription("采购入料", "SFGStockInBill")]
        SFGStockInBill,
        [MemberDescription("自动机材料入库", "FSMStockInBill")]
        FSMStockInBill,
        [MemberDescription("自动机退料", "FSMReturnBill")]
        FSMReturnBill,
        [MemberDescription("装配入库单", "AssembleStockInBill")]
        AssembleStockInBill,
        [MemberDescription("部门退料", "ReturnedMaterialBill")]
        ReturnedMaterialBill,
        [MemberDescription("客户退料", "CustomerReturnedMaterialBill")]
        CustomerReturnedMaterialBill,
    }

    /// <summary>
    /// 出库单类型
    /// </summary>
    public enum StockOutBillTypeEnum
    {
        [MemberDescription("销售发货", "FGStockOutBill")]
        FGStockOutBill,
        [MemberDescription("样品发放", "SampleStockOutBill")]
        SampleStockOutBill,
        [MemberDescription("成套领料", "BatchStockOutBill")]
        BatchStockOutBill,
        [MemberDescription("外加工发料", "EMSStockOutBill")]
        EMSStockOutBill,
        [MemberDescription("采购退料", "SFGStockOutBill")]
        SFGStockOutBill,
        [MemberDescription("自动机发料", "FSMStockOutBill")]
        FSMStockOutBill,
        [MemberDescription("部门领料", "GetMaterialBill")]
        GetMaterialBill,
        [MemberDescription("外加工残次退货", "EMSDPReturnBill")]
        EMSDPReturnBill,
        [MemberDescription("自动机残次退货", "FSMDPReturnBill")]
        FSMDPReturnBill,
        [MemberDescription("客户领料", "CustomerGetMaterialBill")]
        CustomerGetMaterialBill,
        [MemberDescription("散装销售", "SupplierGetMaterialBill")]
        SupplierGetMaterialBill,
    }

    public enum VerifyMethodTypeEnum
    {
        [MemberDescription("任意", "FP_OR_PW_OR_RF")]
        FP_OR_PW_OR_RF,
        [MemberDescription("人脸验证", "FP")]
        FP,
        [MemberDescription("指纹验证", "PIN")]
        PIN,
        [MemberDescription("密码验证", "PW")]
        PW,
        [MemberDescription("IC卡验证", "RF")]
        RF,
        [MemberDescription("人脸或密码", "FP_OR_PW")]
        FP_OR_PW,
        [MemberDescription("人脸或IC卡", "FP_OR_RF")]
        FP_OR_RF,
        [MemberDescription("密码或IC卡", "PW_OR_RF")]
        PW_OR_RF,
        [MemberDescription("指纹和人脸", "PIN_AND_FP")]
        PIN_AND_FP,
        [MemberDescription("人脸和密码", "FP_AND_PW")]
        FP_AND_PW,
        [MemberDescription("人脸和IC卡", "FP_AND_RF")]
        FP_AND_RF,
        [MemberDescription("密码和IC卡", "PW_AND_RF")]
        PW_AND_RF,
        [MemberDescription("人脸和密码和IC卡", "FP_AND_PW_AND_RF")]
        FP_AND_PW_AND_RF,
        [MemberDescription("指纹和人脸和密码", "PIN_AND_FP_AND_PW")]
        PIN_AND_FP_AND_PW,
        [MemberDescription("人脸和IC卡和指纹", "FP_AND_RF_OR_PIN")]
        FP_AND_RF_OR_PIN,
    }

    public enum PrivilegeTypeEnum
    {
        [MemberDescription("普通用户", "User")]
        User,
        [MemberDescription("管理员", "Admin")]
        Admin,
    }
    /// <summary>
    /// 班次
    /// </summary>
    public enum WorkShiftsType
    {
        /// <summary>
        /// 空0
        /// </summary>
        [MemberDescription("  ", " ")]
        Empty = 0,
        /// <summary>
        /// 早班1
        /// </summary>
        [MemberDescription("早班", "ForeShift")]
        ForeShift = 1,
        /// <summary>
        /// 上午班2
        /// </summary>
        [MemberDescription("上午班", "MorningShift")]
        MorningShift = 2,
        /// <summary>
        /// 下午班3
        /// </summary>
        [MemberDescription("下午班", "AfternoonShift")]
        AfternoonShift = 3,
        /// <summary>
        /// 晚班4
        /// </summary>
        [MemberDescription("晚班", "NightShift")]
        NightShift = 4,
    }
    /// <summary>
    /// 机号
    /// </summary>
    public enum MachineType
    {
        /// <summary>
        /// 空0
        /// </summary>
        [MemberDescription(" ", " ")]
        Empty = 0,
        /// <summary>
        /// 1号机1
        /// </summary>
        [MemberDescription("1号机", "One")]
        One = 1,
        /// <summary>
        /// 2号机2
        /// </summary>
        [MemberDescription("2号机", "Two")]
        Two = 2,
        /// <summary>
        /// 3号机3
        /// </summary>
        [MemberDescription("3号机", "Three")]
        Three = 3,
        /// <summary>
        /// 4号机4
        /// </summary>
        [MemberDescription("4号机", "Four")]
        Four = 4,
        /// <summary>
        /// 5号机5
        /// </summary>
        [MemberDescription("5号机", "Five")]
        Five = 5,
        /// <summary>
        /// 6号机6
        /// </summary>
        [MemberDescription("6号机", "Six")]
        Six = 6,
        /// <summary>
        /// 7号机7
        /// </summary>
        [MemberDescription("7号机", "Seven")]
        Seven = 7,
        /// <summary>
        /// 8号机8
        /// </summary>
        [MemberDescription("8号机", "Eight")]
        Eight = 8,
        /// <summary>
        /// 9号机9
        /// </summary>
        [MemberDescription("9号机", "Nine")]
        Nine = 9,
        /// <summary>
        /// 10号机10
        /// </summary>
        [MemberDescription("10号机", "Ten")]
        Ten = 10,
        /// <summary>
        /// 两台机器11
        /// </summary>
        [MemberDescription("两台机器", "Both")]
        Both = 11,
    }
    /// <summary>
    /// 考勤状态
    /// </summary>
    public enum AttStatusType
    {
        /// <summary>
        /// 有效0
        /// </summary>
        [MemberDescription("有效", "White")]  //描述2用于表示颜色
        Valid = 0,
        /// <summary>
        /// 迟到1
        /// </summary>
        [MemberDescription("迟到", "Pink")]
        Late = 1,
        /// <summary>
        /// 早退2
        /// </summary>
        [MemberDescription("早退", "Khaki")]
        Early = 2,
        /// <summary>
        /// 迟到早退3
        /// </summary>
        [MemberDescription("迟到早退", "SalMon")]
        LateEarly = 3,
        /// <summary>
        /// 未签到4
        /// </summary>
        [MemberDescription("未签到", "SkyBlue")]
        NoCheckIn = 4,
        /// <summary>
        /// 未签退5
        /// </summary>
        [MemberDescription("未签退", "DeepSkyBlue")]
        NoCheckOut = 5,
        /// <summary>
        /// 旷工6
        /// </summary>
        [MemberDescription("旷工", "Plum")]
        Absent = 6,
        /// <summary>
        /// 忘打卡7
        /// </summary>
        [MemberDescription("忘打卡", "DarkGray")]
        Forget = 7,
        /// <summary>
        /// 请假8
        /// </summary>
        [MemberDescription("请假", "SpringGreen")]
        Leave = 8,
    }

    /// <summary>
    /// 工资类型
    /// </summary>
    public enum WageTypeEnum
    {
        /// <summary>
        /// 月薪0
        /// </summary>
        [MemberDescription("月薪", "SpringGreen")]
        MonthlyWage = 0,
        /// <summary>
        /// 计时1
        /// </summary>
        [MemberDescription("计时", "Pink")]
        TimeWage = 1,
        /// <summary>
        /// 计件2
        /// </summary>
        [MemberDescription("计件", "SkyBlue")]
        PieceWage = 2,
    }
    /// <summary>
    /// 公司类型
    /// </summary>
    public enum CompanyType
    {
        /// <summary>
        /// 玩具厂0
        /// </summary>
        [MemberDescription("玩具厂", "Factory")]
        Factory = 0,
        /// <summary>
        /// 贸易公司1
        /// </summary>
        [MemberDescription("贸易公司", "Trade")]
        Trade = 1,
    }

    //public enum WarehouseEnum
    //{
    //    [MemberDescription("卖场", "673e26c6-41cc-4d4f-97b5-4cc2585a517e")]
    //    Shop = 0,
    //    [MemberDescription("仓库", "53dc81eb-3a58-4ab5-af1a-8cb7dca8b64c")]
    //    Warehouse = 1,
    //}
}
