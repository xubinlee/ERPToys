using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
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

    /// <summary>
    /// 主菜单项
    /// </summary>
    public enum MainMenuName
    {
        /// <summary>
        /// 公司资料
        /// </summary>
        Company = 1,
        /// <summary>
        /// 职工资料
        /// </summary>
        Staff = 2,
        /// <summary>
        /// 货品资料
        /// </summary>
        Goods = 3,
        /// <summary>
        /// 入库单录入
        /// </summary>
        InStoreBill = 4,
        /// <summary>
        /// 入库单查询
        /// </summary>
        InStoreQuery = 5,
    }

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
    public enum OrderType
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
    public enum CustomerType
    {
        /// <summary>
        /// 内销
        /// </summary>
        DomesticSales = 0,
        /// <summary>
        /// 外销
        /// </summary>
        ExportSales = 1,
    }
    /// <summary>
    /// 供应商类型
    /// </summary>
    public enum SupplierType
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
    public enum GoodsBigType
    {
        /// <summary>
        /// 所有-1
        /// </summary>
        [MemberDescription("所有", "All")]
        All = -1,
        /// <summary>
        /// 成品0
        /// </summary>
        [MemberDescription("成品", "Goods")]
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
        [MemberDescription("原料", "Material")]
        Material = 3,
        /// <summary>
        /// 模具4
        /// </summary>
        [MemberDescription("模具", "Mold")]
        Mold = 4,
        /// <summary>
        /// 筐袋5
        /// </summary>
        [MemberDescription("筐袋", "Basket")]
        Basket = 5,
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
    public enum WageType
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
    /// 工资类型
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
}
