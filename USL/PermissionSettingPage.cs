using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IBase;
using DBML;
using Utility;
using CommonLibrary;
using Factory;
using BLL;
using DevExpress.XtraTreeList.Nodes;

namespace USL
{
    public partial class PermissionSettingPage : DevExpress.XtraEditors.XtraUserControl, IItemDetail
    {
        List<ButtonPermission> btnPermissionList;
        DataSet dsPermission;
        public PermissionSettingPage()
        {
            InitializeComponent();
            BindData();
            
            layoutView.ShowFindPanel();
        }

        public void BindData()
        {
            vUsersInfoBindingSource.DataSource = BLLFty.Create<UsersInfoBLL>().GetLoginUsersInfo();// MainForm.dataSourceList[typeof(List<VUsersInfo>)];
            dsPermission = IListDataSet.ToDataSet<Permission>(((List<Permission>)MainForm.dataSourceList[typeof(List<Permission>)]).FindAll(o => o.UserID == MainForm.usersInfo.ID));
            if (dsPermission.Tables[0].Rows.Count > 0)
            {
                cuTreeListPermission.DataSource = dsPermission.Tables[0];
                cuTreeListPermission.CheckedStateFieldName = "CheckBoxState";
                cuTreeListPermission.Columns["Caption"].Caption = "功能名称";
                cuTreeListPermission.Columns["Caption"].OptionsColumn.AllowEdit = false;
                cuTreeListPermission.Columns["SerialNo"].Visible = false;
                cuTreeListPermission.Columns["UserID"].Visible = false;
                cuTreeListPermission.Columns["CheckBoxState"].Visible = false;
            }
        }
        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Edit()
        {
            throw new NotImplementedException();
        }

        public void Del()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                bool flag = false;
                if (dsPermission == null)
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "该用户没有操作权限");
                    flag = true;
                }
                if (btnPermissionList == null)
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "该用户没有按钮控制权限");
                    flag = true;
                }
                if (flag)
                    return false;
                BLLFty.Create<PermissionBLL>().Update(IListDataSet.DataSetToIList<Permission>(dsPermission, 0).ToList(), btnPermissionList);
                //vStockOutBillDtlForPrintBindingSource.DataSource = BLLFty.Create<StockOutBillBLL>().GetStockOutBillDtlForPrint(hd.ID);
                //gvBillDtlForPrint.BestFitColumns();
                CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "保存成功");
                return true;
            }
            catch (Exception ex)
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), ex.Message);
                return false;
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        public bool Audit()
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            throw new NotImplementedException();
        }

        private void layoutView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetPermission(sender);
        }

        private void layoutView_RowCountChanged(object sender, EventArgs e)
        {
            GetPermission(sender);
        }

        void GetPermission(object sender)
        {
            VUsersInfo user = ((DevExpress.XtraGrid.Views.Layout.LayoutView)sender).GetFocusedRow() as VUsersInfo;
            if (user != null)
            {
                dsPermission = IListDataSet.ToDataSet<Permission>(((List<Permission>)MainForm.dataSourceList[typeof(List<Permission>)]).FindAll(o => o.UserID == user.ID));
                cuTreeListPermission.DataSource = dsPermission.Tables[0];
                cuTreeListPermission.ExpandAll();
                foreach (TreeListNode node in cuTreeListPermission.GetNodeList())
                {
                    DataRowView drv = cuTreeListPermission.GetDataRecordByNode(node) as DataRowView;
                    if (drv != null)
                    {
                        node.Checked = (bool)drv["CheckBoxState"];
                    }
                }
                buttonPermissionBindingSource.DataSource = btnPermissionList = ((List<ButtonPermission>)MainForm.dataSourceList[typeof(List<ButtonPermission>)]).FindAll(o => o.UserID == user.ID);
            }
        }

        private void cuTreeListPermission_CustomDrawNodeCheckBox(object sender, DevExpress.XtraTreeList.CustomDrawNodeCheckBoxEventArgs e)
        {
            bool flag = false;
            if (MainForm.ISnowSoftVersion == ISnowSoftVersion.ALL)
                return;
            else if (MainForm.ISnowSoftVersion == ISnowSoftVersion.EMS || MainForm.ISnowSoftVersion == ISnowSoftVersion.FSM)
                flag = true;
            if (GetVersion().Contains(e.Node.GetDisplayText("Caption")) == flag)
            {
                //e.ObjectArgs.State = DevExpress.Utils.Drawing.ObjectState.Disabled;
                e.Handled = true;
            }
        }

        private void cuTreeListPermission_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            bool flag = false;
            if (MainForm.ISnowSoftVersion == ISnowSoftVersion.ALL)
                return;
            else if (MainForm.ISnowSoftVersion == ISnowSoftVersion.EMS || MainForm.ISnowSoftVersion == ISnowSoftVersion.FSM)
                flag = true;
            if (GetVersion().Contains(e.Node.GetDisplayText("Caption")) == flag)
            {
                e.State = CheckState.Unchecked;
            }
        }

        private void cuTreeListPermission_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            bool flag = false;
            if (MainForm.ISnowSoftVersion == ISnowSoftVersion.ALL)
                if (MainForm.Company.Contains("镇阳"))
                    return;
                else
                    flag = true;
            else if (MainForm.ISnowSoftVersion == ISnowSoftVersion.EMS || MainForm.ISnowSoftVersion == ISnowSoftVersion.FSM)
                flag = true;
            if (GetVersion().Contains(e.CellText) == flag)
            {
                e.Appearance.ForeColor = Color.Gray;
            }
        }

        private List<string> GetVersion()
        {
            List<string> list = new List<string>();
            switch (MainForm.ISnowSoftVersion)
            {
                case ISnowSoftVersion.ALL:
                    list = GetWage();
                    break;
                case ISnowSoftVersion.Procurement:
                    list = GetProcurement();
                    break;
                case ISnowSoftVersion.Sales:
                    list = GetSales();
                    break;
                case ISnowSoftVersion.SalesManagement:
                    list = GetSalesManagement();
                    break;
                case ISnowSoftVersion.PurchaseSellStock:
                    list = GetPurchaseSellStock();
                    break;
                case ISnowSoftVersion.EMS:
                    list = GetEMS();
                    break;
                case ISnowSoftVersion.FSM:
                    list = GetEMS();
                    break;
                default:
                    break;
            }
            return list;
        }

        /// <summary>
        /// 采购功能
        /// </summary>
        /// <returns></returns>
        private List<string> GetProcurement()
        {
            List<string> list = new List<string>();
            //基础资料
            list.Add("职工资料");
            list.Add("供应商资料");
            list.Add("物料资料");
            list.Add("货品类型");
            //采购管理
	    list.Add("采购管理");
            list.Add("供应商商品售价");
            list.Add("采购入料单");
            list.Add("采购入料单查询");
            list.Add("采购退料单");
            list.Add("采购退料单查询");
            //财务结算
            list.Add("付款单");
            list.Add("付款单查询");
            list.Add("供应商结算对账单");
            //系统信息
            list.Add("系统信息");
            list.Add("提醒列表");
            list.Add("权限设置");
            list.Add("关于 冰雪软件");
            return list;
        }

        /// <summary>
        /// 销售发货功能
        /// </summary>
        /// <returns></returns>
        private List<string> GetSales()
        {
            List<string> list = new List<string>();
            //基础资料
            list.Add("职工资料");
            list.Add("客户资料");
            list.Add("成品资料");
            list.Add("货品类型");
            list.Add("包装方式");
            //销售管理
            list.Add("客户商品售价");
            list.Add("发货单");
            list.Add("发货单查询");
            list.Add("销售退货单");
            list.Add("销售退货单查询");
            //财务结算
            list.Add("收款单");
            list.Add("收款单查询");
            list.Add("客户结算对账单");
            //报表管理
            list.Add("销售单据汇总表");
            list.Add("客户销售汇总表");
            list.Add("商品销售汇总表");
            list.Add("客户商品销售汇总表");
            //系统信息
            list.Add("系统信息");
            list.Add("提醒列表");
            list.Add("权限设置");
            list.Add("关于 冰雪软件");
            return list;
        }

        /// <summary>
        /// 销售管理（带成品出入库库存）
        /// </summary>
        /// <returns></returns>
        private List<string> GetSalesManagement()
        {
            List<string> list = new List<string>();
            //基础资料
            list.Add("职工资料");
            list.Add("客户资料");
            list.Add("成品资料");
            list.Add("货品类型");
            list.Add("包装方式");
            //销售管理
            list.Add("客户商品售价");
            list.Add("订货单");
            list.Add("订货单查询");
            list.Add("发货单");
            list.Add("发货单查询");
            list.Add("销售退货单");
            list.Add("销售退货单查询");
            //生产管理
            list.Add("成品布产单");
            list.Add("成品布产单查询");
            list.Add("成品入库单");
            list.Add("成品入库单查询");
            //库存管理
            list.Add("成品库存查询");
            list.Add("成品库存明细");
            list.Add("账页查询");
            list.Add("存货盘点");
            list.Add("盘点盈亏表");
            //财务结算
            list.Add("收款单");
            list.Add("收款单查询");
            list.Add("客户结算对账单");
            //报表管理
            list.Add("销售单据汇总表");
            list.Add("客户销售汇总表");
            list.Add("商品销售汇总表");
            list.Add("客户商品销售汇总表");
            //系统信息
            list.Add("系统信息");
            list.Add("提醒列表");
            list.Add("权限设置");
            list.Add("关于 冰雪软件");
            return list;
        }

        /// <summary>
        /// 进销存
        /// </summary>
        /// <returns></returns>
        private List<string> GetPurchaseSellStock()
        {
            List<string> list = new List<string>();
            //基础资料
            list.Add("基础资料");
            list.Add("部门资料");
            list.Add("职工资料");
            list.Add("客户资料");
            list.Add("供应商资料");
            list.Add("成品资料");
            list.Add("物料资料");
            list.Add("货品类型");
            list.Add("包装方式");
            //采购管理
            list.Add("采购管理");
            list.Add("供应商商品售价");
            list.Add("采购入料单");
            list.Add("采购入料单查询");
            list.Add("采购退料单");
            list.Add("采购退料单查询");
            //销售管理
            list.Add("销售管理");
            list.Add("客户商品售价");
            list.Add("订货单");
            list.Add("订货单查询");
            list.Add("发货单");
            list.Add("发货单查询");
            list.Add("销售退货单");
            list.Add("销售退货单查询");
            list.Add("样品发放情况");
            //生产管理
            list.Add("成品布产单");
            list.Add("成品布产单查询");
            list.Add("成品入库单");
            list.Add("成品入库单查询");
            //库存管理
            list.Add("库存管理");
            list.Add("领料出库单");
            list.Add("领料出库单查询");
            list.Add("退料入库单");
            list.Add("退料入库单查询");
            list.Add("成品库存查询");
            list.Add("成品库存明细");
            list.Add("物料库存查询");
            list.Add("物料库存明细");
            list.Add("账页查询");
            list.Add("存货盘点");
            list.Add("盘点盈亏表");
            //财务结算
            list.Add("财务结算");
            list.Add("收款单");
            list.Add("收款单查询");
            list.Add("客户结算对账单");
            list.Add("付款单");
            list.Add("付款单查询");
            list.Add("供应商结算对账单");
            //报表管理
            list.Add("销售单据汇总表");
            list.Add("客户销售汇总表");
            list.Add("商品销售汇总表");
            list.Add("客户商品销售汇总表");
            //系统信息
            list.Add("系统信息");
            list.Add("提醒列表");
            list.Add("权限设置");
            list.Add("关于 冰雪软件");
            return list;
        }

        /// <summary>
        /// 外加工
        /// </summary>
        /// <returns></returns>
        private List<string> GetEMS()
        {
            List<string> list = new List<string>();
            //除了自动机都要
            list.Add("自动机");
            list.Add("模具清单");
            list.Add("模具分配");
            list.Add("模具原料清单");
            list.Add("模具布产单");
            list.Add("模具布产单查询");
            list.Add("材料入库单");
            list.Add("材料入库单查询");
            list.Add("自动机库存查询");
            return list;
        }

        /// <summary>
        /// 自动机
        /// </summary>
        /// <returns></returns>
        private List<string> GetFSM()
        {
            List<string> list = new List<string>();
            //除了外加工都要
            list.Add("外加工");
            list.Add("投料单");
            list.Add("投料单查询");
            list.Add("产品回收单");
            list.Add("产品回收单查询");
            list.Add("外加工退料单");
            list.Add("外加工退料单查询");
            list.Add("外加工库存查询");
            return list;
        }

        /// <summary>
        /// 工资
        /// </summary>
        /// <returns></returns>
        private List<string> GetWage()
        {
            List<string> list = new List<string>();
            //不开放工资功能
            list.Add("工资管理");
            list.Add("生产排程");
            list.Add("日程工资明细");
            list.Add("工资结算单");
            list.Add("工资结算单查询");
            //不开放考勤功能
            list.Add("考勤管理");
            list.Add("出勤记录");
            list.Add("人员考勤");
            list.Add("考勤明细");
            list.Add("班次时段设置");
            list.Add("人员排班");
            return list;
        }
    }
}
