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
using Factory;
using BLL;
using Utility;
using CommonLibrary;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace USL
{
    public partial class ReceiptBillPage : DevExpress.XtraEditors.XtraUserControl, IItemDetail, IExtensions
    {
        ReceiptBillHd hd;
        List<VReceiptBillDtl> dtl;
        List<StatementOfAccountToCustomerReport> soa;
        Guid headID;
        //String billType;
        List<TypesList> types;   //类型列表

        public ReceiptBillHd Hd
        {
            get
            {
                return hd;
            }

            set
            {
                hd = value;
            }
        }

        public ReceiptBillPage(Guid hdID)
        {
            InitializeComponent();
            if (MainForm.Company.Contains("创萌"))
            {
                this.colBillAMT.Caption = "单据金额(分)";
                this.colReceiptedAMT.Caption = "已收金额(分)";
                this.colUnReceiptedAMT.Caption = "未收金额(分)";
            }
            else
            {
                this.colBillAMT.Caption = "单据金额";
                this.colReceiptedAMT.Caption = "已收金额";
                this.colUnReceiptedAMT.Caption = "未收金额";
            }
            gridView.ShowFindPanel();
            //设置合计列
            MainForm.SetSummaryItemColumns(gvSOA);
            headID = hdID;
            BindData(headID);
            if (MainForm.Company.Contains("纸"))
            {
                colMainMark.Visible = false;
                colQty.Caption = "数量";
                col正唛.Visible = false;
                col箱数.Caption= "数量";
                col装箱数.Visible = false;
                col总数量.Visible = false;
                col外箱规格.Visible = false;
            }
            if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                col额外费用.Visible = true;
            else
                col额外费用.Visible = false;
        }

        public void BindData(Guid hdID)
        {
            gridControl.BeginUpdate();
            if (hdID != Guid.Empty)
            {
                headID = hdID;
                receiptBillHdBindingSource.DataSource = hd = BLLFty.Create<ReceiptBillBLL>().GetReceiptBillHd(hdID);
                switch (types.Find(o => o.Type == TypesListConstants.ReceiptBillType && o.No == int.Parse(lueBillType.EditValue.ToString())).SubType)
                {
                    case TypesListConstants.SalesReceipt:
                        //dtl = ((List<VReceiptBillDtl>)MainForm.dataSourceList[typeof(List<VReceiptBillDtl>)]).FindAll(o =>
                        //            o.CompanyID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Type == int.Parse(lueBillType.EditValue.ToString()));
                        dtl = BLLFty.Create<ReceiptBillBLL>().GetVReceiptBillDtl().FindAll(o =>
                                    o.CompanyID == new Guid(lueBusinessContact.EditValue.ToString()) && (o.Type == 0 || o.Type == 2));
                        break;
                    case TypesListConstants.PurchaseReturnReceipt:
                        dtl = BLLFty.Create<ReceiptBillBLL>().GetVReceiptBillDtl().FindAll(o =>
                                    o.SupplierID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Type == int.Parse(lueBillType.EditValue.ToString()));
                        break;
                }
                List<VReceiptBill> list = ((List<VReceiptBill>)MainForm.dataSourceList[typeof(List<VReceiptBill>)]).FindAll(o => o.HdID == hdID);
                for (int i = dtl.Count - 1; i >= 0; i--)
                {
                    VReceiptBill obj = list.Find(o => o.BillID == dtl[i].BillID);
                    if (obj != null)
                    {
                        dtl[i].ReceiptedAMT = obj.已收金额;
                        dtl[i].UnReceiptedAMT = obj.未收金额;
                        dtl[i].LastReceiptedAMT = obj.本次收款;
                        dtl[i].CheckItem = true;
                    }
                    else
                        dtl.RemoveAt(i);
                }
                vReceiptBillDtlBindingSource.DataSource = dtl;
                statementOfAccountToCustomerReportBindingSource.DataSource = soa = 
                    ((List<StatementOfAccountToCustomerReport>)MainForm.dataSourceList[typeof(List<StatementOfAccountToCustomerReport>)]).FindAll(o => o.收款单号 == hd.BillNo);
                decimal billAMT = dtl.Sum(o => o.LastReceiptedAMT.Value);
                meLastAMT.EditValue = billAMT;
                meTotalAMT.EditValue = (hd.Balance == null ? 0 : hd.Balance) + billAMT;
            }
            types = MainForm.dataSourceList[typeof(List<TypesList>)] as List<TypesList>;
            //单据类型
            billTypeBindingSource.DataSource = types.FindAll(o => o.Type == TypesListConstants.ReceiptBillType && o.No != 2);//不显示销售退货付款类型
            pOClearBindingSource.DataSource = types.FindAll(o => o.Type == TypesListConstants.POClearType);
            vUsersInfoBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VUsersInfo>)];
            gridView.BestFitColumns();
            gridView.FindFilterText = string.Empty;
            gridControl.EndUpdate();
        }

        public void Add()
        {
            receiptBillHdBindingSource.DataSource = hd = new ReceiptBillHd();
            vReceiptBillDtlBindingSource.DataSource = dtl = new List<VReceiptBillDtl>();
            //string no = BLLFty.Create<ReceiptBillBLL>().GetMaxBillNo();
            //if (no == null)
            //    hd.BillNo = "SK" + DateTime.Now.ToString("yyyyMMdd") + "001";
            //else
            //{
            //    if (no.Substring(2, 8).Equals(DateTime.Now.ToString("yyyyMMdd")))
            //        hd.BillNo = "SK" + DateTime.Now.ToString("yyyyMMdd") + Convert.ToString(int.Parse(no.Substring(10, 3)) + 1).PadLeft(3, '0');
            //    else
            //        hd.BillNo = "SK" + DateTime.Now.ToString("yyyyMMdd") + "001";
            //}
            hd.BillNo = MainForm.GetBillMaxBillNo(MainMenuConstants.ReceiptBill, "SK");
            meLastAMT.EditValue = null;
            meTotalAMT.EditValue = null;
            headID = Guid.Empty;
            gridView.FindFilterText = string.Empty;
            deBillDate.EditValue = DateTime.Today;
            deBillDate.Focus();
            lueBillType_EditValueChanged(null, null);
        }

        public void Edit()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 刷新查询界面
        /// </summary>
        void QueryPageRefresh()
        {
            if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.ReceiptBillQuery))
            {
                DataQueryPage page = MainForm.itemDetailList[MainMenuConstants.ReceiptBillQuery] as DataQueryPage;
                //MainForm.GetDataSource();
                MainForm.dataSourceList[typeof(List<VReceiptBill>)] = BLLFty.Create<ReceiptBillBLL>().GetReceiptBill();
                page.InitGrid(MainForm.GetData(MainMenuConstants.ReceiptBillQuery));
            }
        }

        public void Del()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                System.Windows.Forms.DialogResult result = XtraMessageBox.Show("确定要删除选择的记录吗?", "操作提示",
                System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    if (hd != null)
                    {
                        ReceiptBillHd dCheck = BLLFty.Create<ReceiptBillBLL>().GetReceiptBillHd(hd.ID);
                        if (dCheck.Status == (int)BillStatus.UnAudited)
                            BLLFty.Create<ReceiptBillBLL>().Delete(hd.ID);
                        else
                        {
                            CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "该单据已审核，不允许删除。");
                            return;
                        }

                    }
                    //刷新查询界面
                    QueryPageRefresh();
                    receiptBillHdBindingSource.DataSource = hd = new ReceiptBillHd();
                    vReceiptBillDtlBindingSource.DataSource = dtl = new List<VReceiptBillDtl>();
                    CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "删除成功");
                }
            }
            catch (Exception ex)
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), ex.Message);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        bool BillValidated()
        {
            bool flag = true;
            if (hd == null)
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "请完整填写表头信息");
                flag = false;
            }
            //if (dtl == null || dtl.Count == 0 || gridView.RowCount == 0)
            if (dtl == null || gridView.RowCount == 0)
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "请完整填写货品信息");
                flag = false;
            }
            if (lueBillType.EditValue == null)
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "请填写单据类型");
                flag = false;
            }
            if (luePOClear.EditValue == null)
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "请填写结算方式");
                flag = false;
            }
            if (string.IsNullOrEmpty(lueBusinessContact.Text.Trim()))
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "请填写业务往来信息");
                flag = false;
            }
            return flag;
        }

        void getCheckAMT()
        {
            //获取明细列表界面数据（筛选后数据）
            List<VReceiptBillDtl> rDtl = new List<VReceiptBillDtl>();
            for (int i = 0; i < gridView.RowCount; i++)
            {
                if (gridView.GetRow(i) != null && Convert.ToBoolean(gridView.GetRowCellValue(i, colCheckItem)))
                    rDtl.Add((VReceiptBillDtl)gridView.GetRow(i));
            }
            decimal billAMT = rDtl.Sum(o => o.LastReceiptedAMT.Value);
            meLastAMT.EditValue = billAMT;
            meTotalAMT.EditValue = (hd.Balance == null ? 0 : hd.Balance) + billAMT;
        }

        public bool Save()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                gridView.CloseEditForm();
                hd = receiptBillHdBindingSource.DataSource as ReceiptBillHd;
                dtl = vReceiptBillDtlBindingSource.DataSource as List<VReceiptBillDtl>;
                if (string.IsNullOrEmpty(txtBillNo.Text.Trim()))
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "单据编号不能为空，请点击添加按钮添加单据。");
                    return false;
                }
                if (BillValidated() == false)
                    return false;
                if (headID == Guid.Empty)
                    hd.ID = Guid.NewGuid();
                hd.Maker = MainForm.usersInfo.ID;
                hd.MakeDate = DateTime.Now;
                hd.Auditor = null;
                hd.AuditDate = null;
                hd.Status = 0;
                //获取明细列表界面数据（筛选后数据）
                List<VReceiptBillDtl> rDtl = new List<VReceiptBillDtl>();
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    if (gridView.GetRow(i) != null && Convert.ToBoolean(gridView.GetRowCellValue(i, colCheckItem)))
                        rDtl.Add((VReceiptBillDtl)gridView.GetRow(i));
                }
                List<ReceiptBillDtl> dtlList = new List<ReceiptBillDtl>();
                //List<StockInBillHd> siHdList = new List<StockInBillHd>();
                //List<StockOutBillHd> soHdList = new List<StockOutBillHd>();
                bool errFlag = false;
                if (rDtl.Count == 0)
                {
                    errFlag = true;
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "请选择需要收款的单据信息");
                }
                foreach (VReceiptBillDtl item in rDtl)
                {
                    //if (item.LastReceiptedAMT.Value == 0)
                    //{
                    //    errFlag = true;
                    //    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), string.Format("单据[{0}]的本次收款不能为0", item.BillNo));
                    //    continue;
                    //}
                    //if (item.LastReceiptedAMT.Value > item.UnReceiptedAMT)
                    //{
                    //    errFlag = true;
                    //    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), string.Format("单据[{0}]的本次收款不能大于未收金额", item.BillNo));
                    //    continue;
                    //}
                    ReceiptBillDtl obj = new ReceiptBillDtl();
                    obj.ID = Guid.NewGuid();
                    obj.HdID = hd.ID;
                    obj.BillID = item.BillID;
                    obj.BillAMT = item.BillAMT.Value;
                    obj.ReceiptedAMT = item.ReceiptedAMT.Value;
                    obj.UnReceiptedAMT = item.UnReceiptedAMT.Value;
                    obj.LastReceiptedAMT = item.LastReceiptedAMT.Value;
                    dtlList.Add(obj);

                    //if (item.BillNo.Contains("RK"))
                    //{
                    //    StockInBillHd siHd = BLLFty.Create<StockInBillBLL>().GetStockInBillHd(item.BillID);
                    //    siHd.Status = (int)BillStatus.UnCleared;
                    //    siHdList.Add(siHd);
                    //}
                    //else
                    //{
                    //    StockOutBillHd soHd = BLLFty.Create<StockOutBillBLL>().GetStockOutBillHd(item.BillID);
                    //    soHd.Status = (int)BillStatus.UnCleared;
                    //    soHdList.Add(soHd);
                    //}
                }
                if (errFlag)
                    return false;
                dtl = rDtl;
                //添加
                if (headID == Guid.Empty)
                {
                    //hd.ID = Guid.NewGuid();
                    BLLFty.Create<ReceiptBillBLL>().Insert(hd, dtlList);
                }
                else//修改
                    BLLFty.Create<ReceiptBillBLL>().Update(hd, dtlList);
                decimal billAMT = rDtl.Sum(o => o.LastReceiptedAMT.Value);
                meLastAMT.EditValue = billAMT;
                meTotalAMT.EditValue = (hd.Balance == null ? 0 : hd.Balance) + billAMT;
                headID = hd.ID;
                MainForm.BillSaveRefresh(MainMenuConstants.ReceiptBillQuery);
                ////MainForm.DataQueryPageRefresh();
                statementOfAccountToCustomerReportBindingSource.DataSource = soa = //BLLFty.Create<ReportBLL>().GetStatementOfAccountToCustomerReport(string.Format("收款单号='{0}'", hd.BillNo));
                    ((List<StatementOfAccountToCustomerReport>)MainForm.dataSourceList[typeof(List<StatementOfAccountToCustomerReport>)]).FindAll(o => o.收款单号 == hd.BillNo);
                //DataQueryPageRefresh();
                //QueryPageRefresh();
                CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "保存成功");
                return true;
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232060)  //违反了PRIMARY KEY约束
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), string.Format("单号:{0}已经存在,请重新添加新单。", hd.BillNo));
                else
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
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                gridView.CloseEditForm();
                if (hd != null)
                {
                    ReceiptBillHd receipt = BLLFty.Create<ReceiptBillBLL>().GetReceiptBillHd(hd.ID);

                    //if ((receipt != null && receipt.Status == (int)BillStatus.UnAudited) || (receipt==null && hd.Status == (int)BillStatus.UnAudited))  //审核
                    //{
                    //    if (Save() == false)
                    //        return false;
                    //}

                    hd.Auditor = MainForm.usersInfo.ID;
                    hd.AuditDate = DateTime.Now;
                    if (receipt != null && receipt.Status == 1)  //取消审核
                        hd.Status = 0;
                    else
                        hd.Status = 1;

                    List<StockInBillHd> siHdList = new List<StockInBillHd>();
                    List<StockOutBillHd> soHdList = new List<StockOutBillHd>();
                    List<Alert> dellist = new List<Alert>();
                    List<VReceiptBill> rDtlList = BLLFty.Create<ReceiptBillBLL>().GetReceiptBill(hd.ID);
                    foreach (VReceiptBill item in rDtlList)
                    {
                        if (item.单据编号.Contains("RK"))
                        {
                            StockInBillHd siHd = BLLFty.Create<StockInBillBLL>().GetStockInBillHd(item.BillID);
                            if (receipt != null && receipt.Status == 1)  //取消审核
                            {
                                //hd.Auditor = MainForm.usersInfo.ID;
                                //hd.AuditDate = DateTime.Now;
                                //hd.Status = 0;

                                //siHd.UnPaidAMT += Math.Abs(item.LastReceiptedAMT.Value);
                                //if (siHd.UnPaidAMT == siHd.BillAMT)
                                siHd.Status = 1;
                                //else
                                //siHd.Status = 2;
                            }
                            else
                            {
                                //if (siHd.UnPaidAMT < Math.Abs(item.LastReceiptedAMT.Value))
                                //if (Math.Abs(siHd.UnPaidAMT.Value) < item.LastReceiptedAMT.Value)
                                //{
                                //    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "本次收款金额不能大于未收金额。");
                                //    return false;
                                //}
                                //siHd.UnPaidAMT -= Math.Abs(item.LastReceiptedAMT.Value);
                                //if (siHd.UnPaidAMT > 0)
                                //    siHd.Status = 2;
                                //else
                                    siHd.Status = 3;
                            }
                            siHdList.Add(siHd);
                        }
                        else
                        {
                            StockOutBillHd soHd = BLLFty.Create<StockOutBillBLL>().GetStockOutBillHd(item.BillID);
                            if (receipt != null && receipt.Status == 1)  //取消审核
                            {
                                //hd.Auditor = MainForm.usersInfo.ID;
                                //hd.AuditDate = DateTime.Now;
                                //hd.Status = 0;

                                //soHd.UnReceiptedAMT += item.LastReceiptedAMT.Value;
                                //if (soHd.UnReceiptedAMT == soHd.BillAMT)
                                soHd.Status = 1;
                                //else
                                //soHd.Status = 2;
                            }
                            else
                            {
                                //if (soHd.UnReceiptedAMT < item.LastReceiptedAMT.Value)
                                //{
                                //    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "本次收款金额不能大于未收金额。");
                                //    return false;
                                //}
                                //soHd.UnReceiptedAMT -= item.LastReceiptedAMT.Value;
                                //if (soHd.UnReceiptedAMT > 0)
                                //    soHd.Status = 2;
                                //else
                                    soHd.Status = 3;
                            }
                            soHdList.Add(soHd);
                        }
                        //删除提醒信息
                        Alert alert = ((List<Alert>)MainForm.dataSourceList[typeof(List<Alert>)]).Find(o => o.BillID == item.BillID);
                        if (alert != null)
                            dellist.Add(alert);
                    }
                    BLLFty.Create<ReceiptBillBLL>().Audit(hd, siHdList, soHdList, dellist);
                    MainForm.SetAlertCount();

                    if (receipt != null && receipt.Status == 1)  //取消审核
                        CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "取消审核成功");
                    else
                        CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "审核成功");
                    BindData(hd.ID);
                    return true;
                }
                else
                {
                    //DataQueryPageRefresh();
                    CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "没有可审核的单据");
                    return false;
                }
            }
            catch (Exception ex)
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), ex.Message);
                return false;
            }
            finally
            {
                MainForm.BillSaveRefresh(MainMenuConstants.ReceiptBillQuery);
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        public void Print()
        {
            PrintSettingController psc = new PrintSettingController(this.gridControl);

            //页眉 
            if (hd != null)
            {
                psc.PrintCompany = MainForm.Company;
                psc.PrintHeader = "收款单";
                psc.PrintSubTitle = MainForm.Contacts.Replace("\\r\\n", "\r\n");
                psc.PrintLeftHeader = "收款单号：" + hd.BillNo + "\r\n"
                    + "收款类型：" + lueBillType.Text + "\r\n"
                    + "    客户：" + lueBusinessContact.Text;
                psc.PrintRightHeader = "收款日期：" + deBillDate.Text + "\r\n"
                    + "结算方式：" + luePOClear.Text + "\r\n"
                    + "联系人：" + txtContacts.EditValue;
                //if (!string.IsNullOrEmpty(meRemark.Text))
                //    psc.PrintRightHeader = "备注：" + meRemark.Text;

                //页脚 
                psc.PrintLeftFooter = "制单人：" + lueMaker.Text + "  制单日期：" + deMakeDate.Text + "\r\n" 
                    + "审核人：" + lueAuditor.Text + "  审核日期：" + deAuditDate.Text; ;
                //psc.PrintFooter = "审核人：" + lueAuditor.Text + "  审核日期：" + deAuditDate.Text;

                //获取明细列表界面数据（筛选后数据）
                List<VReceiptBillDtl> rDtl = new List<VReceiptBillDtl>();
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    if (gridView.GetRow(i) != null && Convert.ToBoolean(gridView.GetRowCellValue(i, colCheckItem)))
                        rDtl.Add((VReceiptBillDtl)gridView.GetRow(i));
                }
                //金额转大写
                //gridView.Columns["BillNo"].Summary.Clear();
                //gridView.Columns["BillNo"].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                //        new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "金额", "合计金额:"+Rexlib.MoneyToUpper(rDtl.Sum(o=>o.LastReceiptedAMT.Value)))});
            }
            //横纵向 
            //psc.LandScape = this.rbtnHorizon.Checked;
            psc.LandScape = MainForm.IsLandScape;

            //纸型 
            psc.PaperKind = MainForm.PrintPaperKind;
            psc.PaperSize = MainForm.PaperSize; //毫米转像素
            //psc.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            //psc.PaperSize.Width = 216;
            //psc.PaperSize.Height = 140;
            //psc.PaperSize = new System.Drawing.Size(216, 140);
            //加载页面设置信息 
            psc.LoadPageSetting();

            psc.Preview();
        }

        private void lueBillType_EditValueChanged(object sender, EventArgs e)
        {
            businessContactBindingSource.DataSource  = null;
            vReceiptBillDtlBindingSource.DataSource = null;
            lueBusinessContact.EditValue = null;
            txtContacts.EditValue = null;
            this.lueBusinessContact.DataBindings.Clear();
            vReceiptBillDtlBindingSource.Clear();
            if (!string.IsNullOrEmpty(lueBillType.Text.Trim()))
            {
                switch (types.Find(o => o.Type == TypesListConstants.ReceiptBillType && o.No == int.Parse(lueBillType.EditValue.ToString())).SubType)
                {
                    case TypesListConstants.SalesReceipt:
                        this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.receiptBillHdBindingSource, "CompanyID", true));
                        businessContactBindingSource.DataSource = MainForm.dataSourceList[typeof(List<Company>)];
                        break;
                    case TypesListConstants.PurchaseReturnReceipt:
                        this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.receiptBillHdBindingSource, "SupplierID", true));
                        businessContactBindingSource.DataSource = MainForm.dataSourceList[typeof(List<Supplier>)];
                        break;
                }
            }
            if (hd != null && hd.Status == 0)
            {
                //if (lueBusinessContact.EditValue != null && !string.IsNullOrEmpty(lueBusinessContact.EditValue.ToString()) && lueBillType.EditValue != null)
                if (!string.IsNullOrEmpty(lueBusinessContact.Text.Trim()))
                {
                    switch (types.Find(o => o.Type == TypesListConstants.ReceiptBillType && o.No == int.Parse(lueBillType.EditValue.ToString())).SubType)
                    {
                        case TypesListConstants.SalesReceipt:
                            if (!string.IsNullOrEmpty(lueBusinessContact.Text.Trim()))
                            {
                                //外销客户账期到才可收款，如交货后45天收款
                                Company company = ((List<Company>)MainForm.dataSourceList[typeof(List<Company>)]).Find(o => o.ID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Type == (int)CustomerType.ExportSales);
                                if (company != null && company.AccountPeriod.HasValue && company.AccountPeriod.Value > 0)
                                {
                                    vReceiptBillDtlBindingSource.DataSource = BLLFty.Create<ReceiptBillBLL>().GetVReceiptBillDtl().FindAll(o =>
                                            o.CompanyID == new Guid(lueBusinessContact.EditValue.ToString()) && (o.Type == 0 || o.Type == 2) && o.Status != 3 && o.BillDate.AddDays(company.AccountPeriod.Value) <= DateTime.Now);
                                }
                                else
                                {
                                    if (int.Parse(lueBillType.EditValue.ToString()) == 0)
                                        vReceiptBillDtlBindingSource.DataSource = BLLFty.Create<ReceiptBillBLL>().GetVReceiptBillDtl().FindAll(o =>
                                                o.CompanyID == new Guid(lueBusinessContact.EditValue.ToString()) && (o.Type == 0 || o.Type == 2) && o.Status != 3);
                                    else
                                        vReceiptBillDtlBindingSource.DataSource = BLLFty.Create<ReceiptBillBLL>().GetVReceiptBillDtl().FindAll(o =>
                                                o.CompanyID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Type == int.Parse(lueBillType.EditValue.ToString()) && o.Status != 3);
                                }
                            }
                                break;
                        case TypesListConstants.PurchaseReturnReceipt:
                            vReceiptBillDtlBindingSource.DataSource = BLLFty.Create<ReceiptBillBLL>().GetVReceiptBillDtl().FindAll(o =>
                                    o.SupplierID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Type == int.Parse(lueBillType.EditValue.ToString()) && o.Status != 3);
                            break;
                    }
                }
                else
                    vReceiptBillDtlBindingSource.DataSource = null;
                gridView.BestFitColumns();
            }
        }


        string billType = "";
        private void gridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == colBillNo)
            {
                if (e.DisplayText.Contains("RK"))
                    billType = TypesListConstants.StockInBillType;
                else
                    billType = TypesListConstants.StockOutBillType;
            }
            if (e.Column == colType && !string.IsNullOrEmpty(billType))
            {
                List<TypesList> types = MainForm.dataSourceList[typeof(List<TypesList>)] as List<TypesList>;
                e.DisplayText = types.Find(o => o.Type == billType && o.No == Convert.ToInt32(e.Value)).Name.Trim();
            }
        }

        private void lueBusinessContact_EditValueChanged(object sender, EventArgs e)
        {
            vReceiptBillDtlBindingSource.DataSource  = null;
            vReceiptBillDtlBindingSource.Clear();
            if (!string.IsNullOrEmpty(lueBillType.Text.Trim()) && !string.IsNullOrEmpty(lueBusinessContact.Text.Trim()))
            {
                switch (types.Find(o => o.Type == TypesListConstants.ReceiptBillType && o.No == int.Parse(lueBillType.EditValue.ToString())).SubType)
                {
                    case TypesListConstants.SalesReceipt:
                        Company company = ((LookUpEdit)sender).GetSelectedDataRow() as Company;
                        if (company != null && hd != null)
                        {
                            hd.CompanyID = company.ID;
                            hd.Contacts = company.Contacts;
                            if (!string.IsNullOrEmpty(lueBusinessContact.Text.Trim()))  
                            {
                                //外销客户账期到才可收款，如交货后45天收款
                                Company customer = ((List<Company>)MainForm.dataSourceList[typeof(List<Company>)]).Find(o => o.ID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Type == 1);
                                if (customer != null && customer.AccountPeriod.HasValue && customer.AccountPeriod.Value > 0)
                                {
                                    vReceiptBillDtlBindingSource.DataSource = BLLFty.Create<ReceiptBillBLL>().GetVReceiptBillDtl().FindAll(o =>
                                            o.CompanyID == new Guid(lueBusinessContact.EditValue.ToString()) && (o.Type == 0 || o.Type == 2) && o.Status != 3 && o.BillDate.AddDays(customer.AccountPeriod.Value) <= DateTime.Now);
                                }
                                else
                                {
                                    if (int.Parse(lueBillType.EditValue.ToString()) == 0)//销售收款时，同时处理销售退货
                                        vReceiptBillDtlBindingSource.DataSource = BLLFty.Create<ReceiptBillBLL>().GetVReceiptBillDtl().FindAll(o =>
                                                o.CompanyID == new Guid(lueBusinessContact.EditValue.ToString()) && (o.Type == 0 || o.Type == 2) && o.Status != 3);
                                    else
                                        vReceiptBillDtlBindingSource.DataSource = BLLFty.Create<ReceiptBillBLL>().GetVReceiptBillDtl().FindAll(o =>
                                                o.CompanyID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Type == int.Parse(lueBillType.EditValue.ToString()) && o.Status != 3);
                                }
                            }
                        }
                        //获得上期欠款
                        ReceiptBillHd rHd = BLLFty.Create<ReceiptBillBLL>().GetReceiptBillHd().FindAll(o => o.CompanyID == new Guid(lueBusinessContact.EditValue.ToString())).OrderByDescending(o => o.BillNo).FirstOrDefault(o => o.Status > (int)BillStatus.UnAudited);
                        if (rHd != null)
                        {
                            hd.Balance = rHd.UnReceiptedAMT;
                            meBalance.EditValue = rHd.UnReceiptedAMT;
                        }
                        break;
                    case TypesListConstants.PurchaseReturnReceipt:
                        Supplier supplier = ((LookUpEdit)sender).GetSelectedDataRow() as Supplier;
                        if (supplier != null && hd != null)
                        {
                            hd.SupplierID = supplier.ID;
                            hd.Contacts = supplier.Contacts;
                            vReceiptBillDtlBindingSource.DataSource  = BLLFty.Create<ReceiptBillBLL>().GetVReceiptBillDtl().FindAll(o =>
                                    o.SupplierID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Type == int.Parse(lueBillType.EditValue.ToString()) &&  o.Status != 3);

                        }
                        //获得上期欠款
                        ReceiptBillHd rsHd = BLLFty.Create<ReceiptBillBLL>().GetReceiptBillHd().FindAll(o => o.SupplierID == new Guid(lueBusinessContact.EditValue.ToString())).OrderByDescending(o => o.BillNo).FirstOrDefault(o => o.Status > (int)BillStatus.UnAudited);
                        if (rsHd != null)
                        {
                            hd.Balance = rsHd.UnReceiptedAMT;
                            meBalance.EditValue = rsHd.UnReceiptedAMT;
                        }
                        break;
                }
            }
            else
                vReceiptBillDtlBindingSource.DataSource  = null;
            gridView.BestFitColumns();
        }

        private void gridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            List<VReceiptBillDtl> list = ((BindingSource)view.DataSource).DataSource as List<VReceiptBillDtl>;
            if (e.IsGetData && list != null && list.Count > 0)
            {
                if (list[e.ListSourceRowIndex].BillNo.Contains("RK"))
                {
                    List<VStockInBill> bill = ((List<VStockInBill>)MainForm.dataSourceList[typeof(List<VStockInBill>)]).FindAll(o => o.HdID == list[e.ListSourceRowIndex].BillID);
                    if (bill != null)
                    {
                        if (e.Column == colQty)
                            e.Value = bill.Sum(o => o.箱数);
                    }
                }
                else
                {
                    List<VStockOutBill> bill = ((List<VStockOutBill>)MainForm.dataSourceList[typeof(List<VStockOutBill>)]).FindAll(o => o.HdID == list[e.ListSourceRowIndex].BillID);
                    if (bill != null)
                    {
                        if (e.Column == colQty)
                            e.Value = bill.Sum(o => o.箱数);
                    }
                }
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBillNo.Text.Trim()))
            {
                List<ReceiptBillHd> bills = ((List<ReceiptBillHd>)MainForm.dataSourceList[typeof(List<ReceiptBillHd>)]).OrderBy(o => o.BillNo).ToList();
                for (int i = 0; i < bills.Count; i++)
                {
                    if (bills[i].BillNo.Equals(txtBillNo.Text.Trim()))
                    {
                        if (i - 1 >= 0)
                        {
                            BindData(bills[i - 1].ID);
                            btnNext.Enabled = true;
                            if (i - 1 == 0)
                                btnPrev.Enabled = false;
                            if (bills[i - 1].Status == 0)
                                MainForm.itemDetailPageList[MainMenuConstants.ReceiptBill].setNavButtonStatus(MainForm.mainMenuList[MainMenuConstants.ReceiptBill], ButtonType.btnSave);
                            else
                                MainForm.itemDetailPageList[MainMenuConstants.ReceiptBill].setNavButtonStatus(MainForm.mainMenuList[MainMenuConstants.ReceiptBill], ButtonType.btnAudit);
                            break;
                        }
                        else
                        {
                            btnPrev.Enabled = false;
                            btnNext.Enabled = true;
                            break;
                        }
                    }
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBillNo.Text.Trim()))
            {
                List<ReceiptBillHd> bills = ((List<ReceiptBillHd>)MainForm.dataSourceList[typeof(List<ReceiptBillHd>)]).OrderBy(o => o.BillNo).ToList();
                for (int i = 0; i < bills.Count; i++)
                {
                    if (bills[i].BillNo.Equals(txtBillNo.Text.Trim()))
                    {
                        if (i + 1 < bills.Count)
                        {
                            BindData(bills[i + 1].ID);
                            btnPrev.Enabled = true;
                            if (i + 1 == bills.Count - 1)
                                btnNext.Enabled = false;
                            if (bills[i + 1].Status == 0)
                                MainForm.itemDetailPageList[MainMenuConstants.ReceiptBill].setNavButtonStatus(MainForm.mainMenuList[MainMenuConstants.ReceiptBill], ButtonType.btnSave);
                            else
                                MainForm.itemDetailPageList[MainMenuConstants.ReceiptBill].setNavButtonStatus(MainForm.mainMenuList[MainMenuConstants.ReceiptBill], ButtonType.btnAudit);
                            break;
                        }
                        else
                        {
                            btnPrev.Enabled = true;
                            btnNext.Enabled = false;
                            break;
                        }
                    }
                }
            }
        }

        public void Import()
        {
            throw new NotImplementedException();
        }

        public void Export()
        {
            throw new NotImplementedException();
        }

        public void SendData(object data)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                if (string.IsNullOrEmpty(txtBillNo.Text.Trim()))
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "没有可打印的数据");
                    return;
                }
                DevExpress.XtraGrid.GridControl printControl = gcSOA;
                gcSOA.DataSource = soa;
                if (printControl == null || soa == null)
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "没有可打印的数据");
                    return;
                }
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in ((GridView)printControl.MainView).Columns)
                {
                    col.BestFit();
                }
                
                PrintSettingController psc = new PrintSettingController(printControl);

                //页眉 
                if (hd != null)
                {
                    psc.PrintCompany = MainForm.Company;
                    psc.PrintHeader = "客户对账单";
                    psc.PrintSubTitle = MainForm.Contacts.Replace("\\r\\n", "\r\n");
                    psc.PrintLeftHeader = "收款单号：" + hd.BillNo + "\r\n"
                        //+ "结算方式：" + luePOClear.Text + "\r\n"
                        + "    客户：" + lueBusinessContact.Text;
                    psc.PrintRightHeader = "开始日期：" + soa.Min(o => o.出库日期).Value.ToString("yyyy-MM-dd") + "\r\n"
                        + "结束日期：" + soa.Max(o => o.出库日期).Value.ToString("yyyy-MM-dd");// + "\r\n"
                        //+ "客户类型：" + types.FirstOrDefault(o => o.Type == TypesListConstants.CustomerType && o.No == Convert.ToInt32(soa.Min(c => c.客户类型))).Name.Trim();
                    //psc.PrintLeftFooter = MainForm.Accounts.Replace("\\r\\n", "\r\n");
                }
                //获取明细列表界面数据（筛选后数据）
                decimal billAMT = 0;
                List<VReceiptBillDtl> rDtl = new List<VReceiptBillDtl>();
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    if (gridView.GetRow(i) != null && Convert.ToBoolean(gridView.GetRowCellValue(i, colCheckItem)))
                        rDtl.Add((VReceiptBillDtl)gridView.GetRow(i));
                }
                billAMT = rDtl.Sum(o => o.LastReceiptedAMT.Value);
                psc.IsBill = false;
                if (hd.Balance != null)
                    psc.Balance = string.Format("上期结欠:{0:c}     本次收款:{1:c}     共欠:{2:c}", hd.Balance, billAMT, billAMT + hd.Balance);
                //横纵向 
                //psc.LandScape = this.rbtnHorizon.Checked;
                if (MainForm.Company.Contains("镇阳"))
                    psc.LandScape = false;
                else
                    psc.LandScape = true;
                //纸型 
                psc.PaperKind = System.Drawing.Printing.PaperKind.A4;
                //加载页面设置信息 
                psc.LoadPageSetting();

                psc.Preview();
            }
            catch (Exception ex)
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "没有可打印的数据");
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        public object ReceiveData()
        {
            throw new NotImplementedException();
        }

        private void gridControl_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Custom)
            {
                gridView.BeginUpdate();
                if(e.Button.Tag.ToString()=="CheckAll")
                {
                    for (int i = 0; i < gridView.RowCount; i++)
                    {
                        if (gridView.GetRow(i) != null)
                            gridView.SetRowCellValue(i, colCheckItem, true);
                    }
                }
                else if (e.Button.Tag.ToString() == "CheckAllDelete")
                {
                    for (int i = 0; i < gridView.RowCount; i++)
                    {
                        if (gridView.GetRow(i) != null && Convert.ToBoolean(gridView.GetRowCellValue(i, colCheckItem)))
                            gridView.SetRowCellValue(i, colCheckItem, false);
                    }
                }
                gridView.EndUpdate();
            }
        }

        private void meReceiptedAM_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (!string.IsNullOrEmpty(meReceiptedAM.Text))
            {
                decimal totalAMT = 0;
                if (!string.IsNullOrEmpty(meTotalAMT.Text))
                    totalAMT = Convert.ToDecimal(meTotalAMT.EditValue.ToString());
                hd.UnReceiptedAMT = totalAMT - Convert.ToDecimal(e.NewValue);
            }
        }

        private void meBalance_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (!string.IsNullOrEmpty(meBalance.Text))
            {
                decimal lastAMT = 0;
                if (!string.IsNullOrEmpty(meLastAMT.Text))
                    lastAMT = Convert.ToDecimal(meLastAMT.EditValue.ToString());
                meTotalAMT.EditValue = lastAMT + Convert.ToDecimal(e.NewValue);
            }
        }

        private void meTotalAMT_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (!string.IsNullOrEmpty(meTotalAMT.Text))
            {
                decimal amt = 0;
                if (!string.IsNullOrEmpty(meReceiptedAM.Text))
                    amt = Convert.ToDecimal(meReceiptedAM.EditValue.ToString());
                hd.UnReceiptedAMT = Convert.ToDecimal(e.NewValue) - amt;
            }
        }

        private void gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            getCheckAMT();
        }
    }
}
