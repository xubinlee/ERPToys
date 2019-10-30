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
using DBML;
using IBase;
using Factory;
using BLL;
using Utility;
using CommonLibrary;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraReports.UI;

namespace USL
{
    public partial class PaymentBillPage : DevExpress.XtraEditors.XtraUserControl, IItemDetail, IExtensions
    {
        PaymentBillHd hd;
        List<VPaymentBillDtl> dtl;
        List<StatementOfAccountToSupplierReport> soa;
        List<StatementOfAccountMaterialToSupplierReport> soam;
        List<StatementOfAccountSummaryToSupplierReport> soas;
        List<StatementOfAccountBasketToSupplierReport> soab;
        Guid headID;
        //String billType;
        List<TypesList> types;   //类型列表
        String type;

        public PaymentBillHd Hd
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

        public PaymentBillPage(Guid hdID)
        {
            InitializeComponent();
            if (MainForm.Company.Contains("创萌"))
            {
                this.colBillAMT.Caption = "单据金额(分)";
                this.colPaidAMT.Caption = "已付金额(分)";
                this.colUnPaidAMT.Caption = "未付金额(分)";
            }
            else
            {
                this.colBillAMT.Caption = "单据金额";
                this.colPaidAMT.Caption = "已付金额";
                this.colUnPaidAMT.Caption = "未付金额";
            }
            gridView.ShowFindPanel();
            //设置合计列
            MainForm.SetSummaryItemColumns(gvSOA);
            headID = hdID;
            BindData(headID);
            if (MainForm.Company.Contains("纸"))
            {
                col模数.Visible = false;
            }
        }

        public void BindData(Guid hdID)
        {
            gridControl.BeginUpdate();
            types = MainForm.dataSourceList[typeof(List<TypesList>)] as List<TypesList>;
            if (hdID != Guid.Empty)
            {
                headID = hdID;
                paymentBillHdBindingSource.DataSource = hd = BLLFty.Create<PaymentBillBLL>().GetPaymentBillHd(hdID);
                if (!string.IsNullOrEmpty(lueBillType.Text))
                    type = types.Find(o => o.Type == TypesListConstants.PaymentBillType && o.No == int.Parse(lueBillType.EditValue.ToString())).SubType;
                switch (type)
                {
                    case TypesListConstants.SalesReturnPayment:
                        dtl = BLLFty.Create<PaymentBillBLL>().GetVPaymentBillDtl().FindAll(o =>
                                    o.CompanyID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Type == int.Parse(lueBillType.EditValue.ToString()));
                        break;
                    case TypesListConstants.EMSPayment://外加工付款同时处理外加工残次退货
                        dtl = BLLFty.Create<PaymentBillBLL>().GetVPaymentBillDtl().FindAll(o =>
                                    o.SupplierID == new Guid(lueBusinessContact.EditValue.ToString()) && ((o.Type == int.Parse(lueBillType.EditValue.ToString()) && o.BillNo.Contains("RK")) || (o.Type == 7 && o.BillNo.Contains("CK"))));
                        break;
                    case TypesListConstants.FSMPayment://自动机付款同时处理自动机残次退货
                        dtl = BLLFty.Create<PaymentBillBLL>().GetVPaymentBillDtl().FindAll(o =>
                                    o.SupplierID == new Guid(lueBusinessContact.EditValue.ToString()) && ((o.Type == int.Parse(lueBillType.EditValue.ToString()) && o.BillNo.Contains("RK")) || (o.Type == 8 && o.BillNo.Contains("CK"))));
                        break;
                    case TypesListConstants.PurchasePayment://采购付款同时处理采购退款
                        dtl = BLLFty.Create<PaymentBillBLL>().GetVPaymentBillDtl().FindAll(o =>
                                    o.SupplierID == new Guid(lueBusinessContact.EditValue.ToString()) && ((o.Type == 5 && o.BillNo.Contains("RK")) || (o.Type == 4 && o.BillNo.Contains("CK"))));
                        break;
                }
                List<VPaymentBill> list = ((List<VPaymentBill>)MainForm.dataSourceList[typeof(List<VPaymentBill>)]).FindAll(o => o.HdID == hdID);
                if (dtl != null)
                {
                    for (int i = dtl.Count - 1; i >= 0; i--)
                    {
                        VPaymentBill obj = list.Find(o => o.BillID == dtl[i].BillID);
                        if (obj != null)
                        {
                            dtl[i].PaidAMT = obj.已付金额;
                            dtl[i].UnPaidAMT = obj.未付金额;
                            dtl[i].LastPaidAMT = obj.本次付款;
                            dtl[i].CheckItem = true;
                        }
                        else
                            dtl.RemoveAt(i);
                    }
                }
                vPaymentBillDtlBindingSource.DataSource = dtl;
                statementOfAccountToSupplierReportBindingSource.DataSource = soa =
                    ((List<StatementOfAccountToSupplierReport>)MainForm.dataSourceList[typeof(List<StatementOfAccountToSupplierReport>)]).FindAll(o => o.付款单号 == hd.BillNo);
                if (type != null && dtl !=null && dtl.Count >0)
                {
                    if (type == TypesListConstants.FSMPayment)
                    {
                        soas = BLLFty.Create<ReportBLL>().GetStatementOfAccountSummaryToSupplierReport(string.Format("付款单号='{0}'", hd.BillNo));
                        soam = BLLFty.Create<ReportBLL>().GetStatementOfAccountMaterialToSupplierReport(hd.BillNo, hd.SupplierID.Value, dtl.Min(o => o.BillDate), dtl.Max(o => o.BillDate), "FSM");
                        soab = BLLFty.Create<ReportBLL>().GetStatementOfAccountBasketToSupplierReport(hd.BillNo, hd.SupplierID.Value, dtl.Min(o => o.BillDate), dtl.Max(o => o.BillDate), "FSM");
                    }
                    else
                    {
                        soas = null;
                        //soam = BLLFty.Create<ReportBLL>().GetStatementOfAccountOfEMSReport(hd.BillNo, hd.SupplierID.Value, dtl.Min(o => o.BillDate), dtl.Max(o => o.BillDate));
                        soam = BLLFty.Create<ReportBLL>().GetStatementOfAccountMaterialToSupplierReport(hd.BillNo, hd.SupplierID.Value, dtl.Min(o => o.BillDate), dtl.Max(o => o.BillDate), "EMS");
                        soab = BLLFty.Create<ReportBLL>().GetStatementOfAccountBasketToSupplierReport(hd.BillNo, hd.SupplierID.Value, dtl.Min(o => o.BillDate), dtl.Max(o => o.BillDate), "EMS");
                    }

                    decimal billAMT = dtl.Sum(o => o.LastPaidAMT.Value);
                    meLastAMT.EditValue = billAMT;
                    meTotalAMT.EditValue = (hd.Balance == null ? 0 : hd.Balance) + billAMT;
                }
            }
            //单据类型
            billTypeBindingSource.DataSource = types.FindAll(o => o.Type == TypesListConstants.PaymentBillType && o.No != 4);//不显示采购退货收款
            pOClearBindingSource.DataSource = types.FindAll(o => o.Type == TypesListConstants.POClearType);
            vUsersInfoBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VUsersInfo>)];
            gridView.BestFitColumns();
            gridView.FindFilterText = string.Empty;
            gridControl.EndUpdate();
        }

        public void Add()
        {
            paymentBillHdBindingSource.DataSource = hd = new PaymentBillHd();
            vPaymentBillDtlBindingSource.DataSource = dtl = new List<VPaymentBillDtl>();
            //string no = BLLFty.Create<PaymentBillBLL>().GetMaxBillNo();
            //if (no == null)
            //    hd.BillNo = "FK" + DateTime.Now.ToString("yyyyMMdd") + "001";
            //else
            //{
            //    if (no.Substring(2, 8).Equals(DateTime.Now.ToString("yyyyMMdd")))
            //        hd.BillNo = "FK" + DateTime.Now.ToString("yyyyMMdd") + Convert.ToString(int.Parse(no.Substring(10, 3)) + 1).PadLeft(3, '0');
            //    else
            //        hd.BillNo = "FK" + DateTime.Now.ToString("yyyyMMdd") + "001";
            //}
            hd.BillNo = MainForm.GetBillMaxBillNo(MainMenuConstants.PaymentBill, "FK");
            meLastAMT.EditValue = null;
            meTotalAMT.EditValue = null;
            headID = Guid.Empty;
            gridView.FindFilterText = string.Empty;
            deBillDate.EditValue = DateTime.Today;
            deBillDate.Focus();
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
            if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.PaymentBillQuery))
            {
                DataQueryPage page = MainForm.itemDetailList[MainMenuConstants.PaymentBillQuery] as DataQueryPage;
                //MainForm.GetDataSource();
                MainForm.dataSourceList[typeof(List<VPaymentBill>)] = BLLFty.Create<PaymentBillBLL>().GetPaymentBill();
                page.InitGrid(MainForm.GetData(MainMenuConstants.PaymentBillQuery));
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
                        PaymentBillHd dCheck = BLLFty.Create<PaymentBillBLL>().GetPaymentBillHd(hd.ID);
                        if (dCheck.Status == (int)BillStatus.UnAudited)
                            BLLFty.Create<PaymentBillBLL>().Delete(hd.ID);
                        else
                        {
                            CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "该单据已审核，不允许删除。");
                            return;
                        }

                    }
                    //QueryPageRefresh();
                    MainForm.DataQueryPageRefresh();
                    paymentBillHdBindingSource.DataSource = hd = new PaymentBillHd();
                    vPaymentBillDtlBindingSource.DataSource = dtl = new List<VPaymentBillDtl>();
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
            List<VPaymentBillDtl> pDtl = new List<VPaymentBillDtl>();
            for (int i = 0; i < gridView.RowCount; i++)
            {
                if (gridView.GetRow(i) != null && Convert.ToBoolean(gridView.GetRowCellValue(i, colCheckItem)))
                    pDtl.Add((VPaymentBillDtl)gridView.GetRow(i));
            }
            decimal billAMT = pDtl.Sum(o => o.LastPaidAMT.Value);
            meLastAMT.EditValue = billAMT;
            meTotalAMT.EditValue = (hd.Balance == null ? 0 : hd.Balance) + billAMT;
        }

        public bool Save()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                gridView.CloseEditForm();
                hd = paymentBillHdBindingSource.DataSource as PaymentBillHd;
                dtl = vPaymentBillDtlBindingSource.DataSource as List<VPaymentBillDtl>;
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
                List<VPaymentBillDtl> pDtl = new List<VPaymentBillDtl>();
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    if (gridView.GetRow(i) != null && Convert.ToBoolean(gridView.GetRowCellValue(i, colCheckItem)))
                        pDtl.Add((VPaymentBillDtl)gridView.GetRow(i));
                }
                List<PaymentBillDtl> dtlList = new List<PaymentBillDtl>();
                bool errFlag = false;
                if (pDtl.Count == 0)
                {
                    errFlag = true;
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "请选择需要付款的单据信息");
                }
                foreach (VPaymentBillDtl item in pDtl)
                {
                    //if (item.LastPaidAMT.Value == 0)
                    //{
                    //    errFlag = true;
                    //    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), string.Format("单据[{0}]的本次付款不能为0", item.BillNo));
                    //    continue;
                    //}
                    //if (item.LastPaidAMT.Value > item.UnPaidAMT)
                    //{
                    //    errFlag = true;
                    //    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), string.Format("单据[{0}]的本次付款不能大于未付金额", item.BillNo));
                    //    continue;
                    //}
                    PaymentBillDtl obj = new PaymentBillDtl();
                    obj.ID = Guid.NewGuid();
                    obj.HdID = hd.ID;
                    obj.BillID = item.BillID;
                    obj.BillAMT = item.BillAMT.Value;
                    obj.PaidAMT = item.PaidAMT.Value;
                    obj.UnPaidAMT = item.UnPaidAMT.Value;
                    obj.LastPaidAMT = item.LastPaidAMT.Value;
                    dtlList.Add(obj);
                }
                if (errFlag)
                    return false;
                dtl = pDtl;
                //添加
                if (headID == Guid.Empty)
                {
                    //hd.ID = Guid.NewGuid();
                    BLLFty.Create<PaymentBillBLL>().Insert(hd, dtlList);
                }
                else//修改
                    BLLFty.Create<PaymentBillBLL>().Update(hd, dtlList);
                decimal billAMT = pDtl.Sum(o => o.LastPaidAMT.Value);
                meLastAMT.EditValue = billAMT;
                meTotalAMT.EditValue = (hd.Balance == null ? 0 : hd.Balance) + billAMT;
                headID = hd.ID;
                ////MainForm.DataQueryPageRefresh();
                MainForm.BillSaveRefresh(MainMenuConstants.PaymentBillQuery);
                statementOfAccountToSupplierReportBindingSource.DataSource = soa = //BLLFty.Create<ReportBLL>().GetStatementOfAccountToSupplierReport(string.Format("付款单号='{0}'", hd.BillNo));
                    ((List<StatementOfAccountToSupplierReport>)MainForm.dataSourceList[typeof(List<StatementOfAccountToSupplierReport>)]).FindAll(o => o.付款单号 == hd.BillNo);
                if (type == TypesListConstants.FSMPayment)
                {
                    soas = BLLFty.Create<ReportBLL>().GetStatementOfAccountSummaryToSupplierReport(string.Format("付款单号='{0}'", hd.BillNo));
                    soam = BLLFty.Create<ReportBLL>().GetStatementOfAccountMaterialToSupplierReport(hd.BillNo, hd.SupplierID.Value, dtl.Min(o => o.BillDate), dtl.Max(o => o.BillDate), "FSM");
                    soab = BLLFty.Create<ReportBLL>().GetStatementOfAccountBasketToSupplierReport(hd.BillNo, hd.SupplierID.Value, dtl.Min(o => o.BillDate), dtl.Max(o => o.BillDate), "FSM");
                }
                else
                {
                    soas = null;
                    //soam = BLLFty.Create<ReportBLL>().GetStatementOfAccountOfEMSReport(hd.BillNo, hd.SupplierID.Value, dtl.Min(o => o.BillDate), dtl.Max(o => o.BillDate));
                    soam = BLLFty.Create<ReportBLL>().GetStatementOfAccountMaterialToSupplierReport(hd.BillNo, hd.SupplierID.Value, dtl.Min(o => o.BillDate), dtl.Max(o => o.BillDate), "EMS");
                    soab = BLLFty.Create<ReportBLL>().GetStatementOfAccountBasketToSupplierReport(hd.BillNo, hd.SupplierID.Value, dtl.Min(o => o.BillDate), dtl.Max(o => o.BillDate), "EMS");
                }
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
                    PaymentBillHd payment = BLLFty.Create<PaymentBillBLL>().GetPaymentBillHd(hd.ID);

                    //if (payment != null && payment.Status == (int)BillStatus.UnAudited)  //审核
                    //{
                    //    if (Save() == false)
                    //        return false;
                    //}

                    hd.Auditor = MainForm.usersInfo.ID;
                    hd.AuditDate = DateTime.Now;
                    if (payment != null && payment.Status == 1)  //取消审核
                        hd.Status = 0;
                    else
                        hd.Status = 1;

                    List<StockInBillHd> siHdList = new List<StockInBillHd>();
                    List<StockOutBillHd> soHdList = new List<StockOutBillHd>();
                    List<VPaymentBill> pDtlList = BLLFty.Create<PaymentBillBLL>().GetPaymentBill(hd.ID);
                    foreach (VPaymentBill item in pDtlList)
                    {
                        if (item.单据编号.Contains("CK"))
                        {
                            StockOutBillHd soHd = BLLFty.Create<StockOutBillBLL>().GetStockOutBillHd(item.BillID);
                            if (payment != null && payment.Status == 1)  //取消审核
                            {
                                hd.Auditor = MainForm.usersInfo.ID;
                                hd.AuditDate = DateTime.Now;
                                hd.Status = 0;

                                //soHd.UnReceiptedAMT += Math.Abs(item.LastPaidAMT.Value);
                                //if (soHd.UnReceiptedAMT == soHd.BillAMT)
                                soHd.Status = 1;
                                //else
                                //    soHd.Status = 2;
                            }
                            else
                            {
                                //if (soHd.UnReceiptedAMT < Math.Abs(item.LastPaidAMT.Value))
                                //if (Math.Abs(soHd.UnReceiptedAMT.Value) < item.LastPaidAMT.Value)
                                //{
                                //    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "本次付款金额不能大于未付金额。");
                                //    return false;
                                //}
                                //soHd.UnReceiptedAMT -= Math.Abs(item.LastPaidAMT.Value);
                                //if (soHd.UnReceiptedAMT > 0)
                                //    soHd.Status = 2;
                                //else
                                    soHd.Status = 3;
                            }
                            soHdList.Add(soHd);
                        }
                        else
                        {
                            StockInBillHd siHd = BLLFty.Create<StockInBillBLL>().GetStockInBillHd(item.BillID);
                            if (payment != null && payment.Status == 1)  //取消审核
                            {
                                hd.Auditor = MainForm.usersInfo.ID;
                                hd.AuditDate = DateTime.Now;
                                hd.Status = 0;

                                //siHd.UnPaidAMT += item.LastPaidAMT.Value;
                                //if (siHd.UnPaidAMT == siHd.BillAMT)
                                siHd.Status = 1;
                                //else
                                //    siHd.Status = 2;
                            }
                            else
                            {
                                //if (siHd.UnPaidAMT < item.LastPaidAMT.Value)
                                //{
                                //    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "本次付款金额不能大于未付金额。");
                                //    return false;
                                //}
                                //siHd.UnPaidAMT -= item.LastPaidAMT.Value;
                                //if (siHd.UnPaidAMT > 0)
                                //    siHd.Status = 2;
                                //else
                                    siHd.Status = 3;
                            }
                            siHdList.Add(siHd);
                        }
                    }
                    BLLFty.Create<PaymentBillBLL>().Audit(hd, siHdList, soHdList);
                    if (payment != null && payment.Status == 1)  //取消审核
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
                MainForm.BillSaveRefresh(MainMenuConstants.PaymentBillQuery);
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
                psc.PrintHeader = "付款单";
                psc.PrintSubTitle = MainForm.Contacts.Replace("\\r\\n", "\r\n");
                psc.PrintLeftHeader = "付款单号：" + hd.BillNo + "\r\n"
                    + "付款类型：" + lueWarehouse.Text + "\r\n"
                    + "    客户：" + lueBusinessContact.Text;
                psc.PrintRightHeader = "付款日期：" + deBillDate.Text + "\r\n"
                    + "结算方式：" + luePOClear.Text + "\r\n"
                    + "联系人：" + txtContacts.EditValue;
                //if (!string.IsNullOrEmpty(meRemark.Text))
                //    psc.PrintRightHeader = "备注：" + meRemark.Text;

                //页脚 
                psc.PrintLeftFooter = "制单人：" + lueMaker.Text + "  制单日期：" + deMakeDate.Text + "\r\n"
                    + "审核人：" + lueAuditor.Text + "  审核日期：" + deAuditDate.Text; ;
                //psc.PrintFooter = "审核人：" + lueAuditor.Text + "  审核日期：" + deAuditDate.Text;

                //获取明细列表界面数据（筛选后数据）
                List<VPaymentBillDtl> pDtl = new List<VPaymentBillDtl>();
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    if (gridView.GetRow(i) != null)
                        pDtl.Add((VPaymentBillDtl)gridView.GetRow(i));
                }
                //金额转大写
                //gridView.Columns["BillNo"].Summary.Clear();
                //gridView.Columns["BillNo"].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                //        new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "金额", "合计金额:"+Rexlib.MoneyToUpper(pDtl.Sum(o=>o.LastPaidAMT.Value)))});
            }
            //横纵向 
            //psc.LandScape = this.rbtnHorizon.Checked;
            psc.LandScape = MainForm.IsLandScape;

            //纸型 
            psc.PaperKind = MainForm.PrintPaperKind;
            psc.PaperSize = MainForm.PaperSize;
            //加载页面设置信息 
            psc.LoadPageSetting();

            psc.Preview();
        }

        private void lueBillType_EditValueChanged(object sender, EventArgs e)
        {
            businessContactBindingSource.DataSource = null;
            vPaymentBillDtlBindingSource.DataSource = null;
            lueBusinessContact.EditValue = null;
            txtContacts.EditValue = null;
            this.lueBusinessContact.DataBindings.Clear();
            vPaymentBillDtlBindingSource.Clear();
            if (!string.IsNullOrEmpty(lueBillType.Text.Trim()))
            {
                switch (types.Find(o => o.Type == TypesListConstants.PaymentBillType && o.No == int.Parse(lueBillType.EditValue.ToString())).SubType)
                {
                    case TypesListConstants.SalesReturnPayment:
                        this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.paymentBillHdBindingSource, "CompanyID", true));
                        businessContactBindingSource.DataSource = MainForm.dataSourceList[typeof(List<Company>)];
                        break;
                    case TypesListConstants.EMSPayment:
                    case TypesListConstants.PurchasePayment:
                    case TypesListConstants.FSMPayment:
                        this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.paymentBillHdBindingSource, "SupplierID", true));
                        businessContactBindingSource.DataSource = MainForm.dataSourceList[typeof(List<Supplier>)];
                        break;
                }
            }
            if (hd != null && hd.Status == 0)
            {
                //if (lueBusinessContact.EditValue != null && !string.IsNullOrEmpty(lueBusinessContact.EditValue.ToString()) && lueBillType.EditValue != null)
                if (!string.IsNullOrEmpty(lueBusinessContact.Text.Trim()))
                {
                    switch (types.Find(o => o.Type == TypesListConstants.PaymentBillType && o.No == int.Parse(lueBillType.EditValue.ToString())).SubType)
                    {
                        case TypesListConstants.SalesReturnPayment:
                            vPaymentBillDtlBindingSource.DataSource = BLLFty.Create<PaymentBillBLL>().GetVPaymentBillDtl().FindAll(o =>
                                    o.CompanyID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Type == int.Parse(lueBillType.EditValue.ToString()) && o.Status != 3);
                            break;
                        case TypesListConstants.EMSPayment:
                        case TypesListConstants.PurchasePayment:
                        case TypesListConstants.FSMPayment:
                            if (int.Parse(lueBillType.EditValue.ToString()) == 5)// 采购付款同时处理采购退款
                                vPaymentBillDtlBindingSource.DataSource = BLLFty.Create<PaymentBillBLL>().GetVPaymentBillDtl().FindAll(o =>
                                    o.SupplierID == new Guid(lueBusinessContact.EditValue.ToString()) && ((o.Type == 5 && o.BillNo.Contains("RK")) || (o.Type == 4 && o.BillNo.Contains("CK"))) && o.Status != 3);
                            else if (int.Parse(lueBillType.EditValue.ToString()) == 3)//外加工付款同时处理外加工残次退货
                                vPaymentBillDtlBindingSource.DataSource = BLLFty.Create<PaymentBillBLL>().GetVPaymentBillDtl().FindAll(o =>
                                    o.SupplierID == new Guid(lueBusinessContact.EditValue.ToString()) && ((o.Type == 3 && o.BillNo.Contains("RK")) || (o.Type == 7 && o.BillNo.Contains("CK"))) && o.Status != 3);
                            else if (int.Parse(lueBillType.EditValue.ToString()) == 6)//自动机付款同时处理自动机残次退货
                                vPaymentBillDtlBindingSource.DataSource = BLLFty.Create<PaymentBillBLL>().GetVPaymentBillDtl().FindAll(o =>
                                    o.SupplierID == new Guid(lueBusinessContact.EditValue.ToString()) && ((o.Type == 6 && o.BillNo.Contains("RK")) || (o.Type == 8 && o.BillNo.Contains("CK"))) && o.Status != 3);
                            else
                                vPaymentBillDtlBindingSource.DataSource = BLLFty.Create<PaymentBillBLL>().GetVPaymentBillDtl().FindAll(o =>
                                    o.SupplierID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Type == int.Parse(lueBillType.EditValue.ToString()) && o.Status != 3);
                            break;
                    }
                }
                else
                    vPaymentBillDtlBindingSource.DataSource = null;
                gridView.BestFitColumns();
            }
        }

        string billType = "";
        private void gridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == colBillNo)
            {
                if (e.DisplayText.Contains("CK"))
                    billType = TypesListConstants.StockOutBillType;
                else
                    billType = TypesListConstants.StockInBillType;
            }
            if (e.Column == colType && !string.IsNullOrEmpty(billType))
            {
                List<TypesList> types = MainForm.dataSourceList[typeof(List<TypesList>)] as List<TypesList>;
                e.DisplayText = types.Find(o => o.Type == billType && o.No == Convert.ToInt32(e.Value)).Name.Trim();
            }
        }

        private void lueBusinessContact_EditValueChanged(object sender, EventArgs e)
        {
            vPaymentBillDtlBindingSource.DataSource = null;
            vPaymentBillDtlBindingSource.Clear();
            if (!string.IsNullOrEmpty(lueBillType.Text.Trim()) && !string.IsNullOrEmpty(lueBusinessContact.Text.Trim()))
            {
                switch (types.Find(o => o.Type == TypesListConstants.PaymentBillType && o.No == int.Parse(lueBillType.EditValue.ToString())).SubType)
                {
                    case TypesListConstants.SalesReturnPayment:
                        Company company = ((LookUpEdit)sender).GetSelectedDataRow() as Company;
                        if (company != null && hd != null)
                        {
                            hd.CompanyID = company.ID;
                            hd.Contacts = company.Contacts;
                            vPaymentBillDtlBindingSource.DataSource = BLLFty.Create<PaymentBillBLL>().GetVPaymentBillDtl().FindAll(o =>
                                    o.CompanyID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Type == int.Parse(lueBillType.EditValue.ToString()) && o.Status != 3);
                        }
                        //获得上期欠款
                        PaymentBillHd pHd = BLLFty.Create<PaymentBillBLL>().GetPaymentBillHd().FindAll(o=> o.CompanyID == new Guid(lueBusinessContact.EditValue.ToString())).OrderByDescending(o => o.BillNo).FirstOrDefault(o => o.Status > (int)BillStatus.UnAudited);
                        if (pHd != null)
                        {
                            hd.Balance = pHd.UnPaidAMT;
                            meBalance.EditValue = pHd.UnPaidAMT;
                        }
                        break;
                    case TypesListConstants.EMSPayment:
                    case TypesListConstants.PurchasePayment:
                    case TypesListConstants.FSMPayment:
                        Supplier supplier = ((LookUpEdit)sender).GetSelectedDataRow() as Supplier;
                        if (supplier != null && hd != null)
                        {
                            hd.SupplierID = supplier.ID;
                            hd.Contacts = supplier.Contacts;
                            if (int.Parse(lueBillType.EditValue.ToString()) == 5)// 采购付款同时处理采购退款
                                vPaymentBillDtlBindingSource.DataSource = BLLFty.Create<PaymentBillBLL>().GetVPaymentBillDtl().FindAll(o =>
                                    o.SupplierID == new Guid(lueBusinessContact.EditValue.ToString()) && ((o.Type == 5 && o.BillNo.Contains("RK")) || (o.Type == 4 && o.BillNo.Contains("CK"))) && o.Status != 3);
                            else if (int.Parse(lueBillType.EditValue.ToString()) == 3)//外加工付款同时处理外加工残次退货
                                vPaymentBillDtlBindingSource.DataSource = BLLFty.Create<PaymentBillBLL>().GetVPaymentBillDtl().FindAll(o =>
                                    o.SupplierID == new Guid(lueBusinessContact.EditValue.ToString()) && ((o.Type == 3 && o.BillNo.Contains("RK")) || (o.Type == 7 && o.BillNo.Contains("CK"))) && o.Status != 3);
                            else if (int.Parse(lueBillType.EditValue.ToString()) == 6)//自动机付款同时处理自动机残次退货
                                vPaymentBillDtlBindingSource.DataSource = BLLFty.Create<PaymentBillBLL>().GetVPaymentBillDtl().FindAll(o =>
                                    o.SupplierID == new Guid(lueBusinessContact.EditValue.ToString()) && ((o.Type == 6 && o.BillNo.Contains("RK")) || (o.Type == 8 && o.BillNo.Contains("CK"))) && o.Status != 3);
                            else
                                vPaymentBillDtlBindingSource.DataSource = BLLFty.Create<PaymentBillBLL>().GetVPaymentBillDtl().FindAll(o =>
                                        o.SupplierID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Type == int.Parse(lueBillType.EditValue.ToString()) && o.Status != 3);

                        }
                        //获得上期欠款
                        PaymentBillHd psHd = BLLFty.Create<PaymentBillBLL>().GetPaymentBillHd().FindAll(o=> o.SupplierID == new Guid(lueBusinessContact.EditValue.ToString())).OrderByDescending(o => o.BillNo).FirstOrDefault(o => o.Status > (int)BillStatus.UnAudited);
                        if (psHd != null)
                        {
                            hd.Balance = psHd.UnPaidAMT;
                            meBalance.EditValue = psHd.UnPaidAMT;
                        }
                        break;
                }
            }
            else
                vPaymentBillDtlBindingSource.DataSource = null;
            gridView.BestFitColumns();
        }

        private void gridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            List<VPaymentBillDtl> list = ((BindingSource)view.DataSource).DataSource as List<VPaymentBillDtl>;
            if (e.IsGetData && list != null && list.Count > 0)
            {
                if (list[e.ListSourceRowIndex].BillNo.Contains("CK"))
                {
                    List<VMaterialStockOutBill> bill = ((List<VMaterialStockOutBill>)MainForm.dataSourceList[typeof(List<VMaterialStockOutBill>)]).FindAll(o => o.HdID == list[e.ListSourceRowIndex].BillID);
                    if (bill != null)
                    {
                        if (e.Column == colQty)
                            e.Value = bill.Sum(o => o.数量);
                    }
                }
                else
                {
                    List<VMaterialStockInBill> bill = ((List<VMaterialStockInBill>)MainForm.dataSourceList[typeof(List<VMaterialStockInBill>)]).FindAll(o => o.HdID == list[e.ListSourceRowIndex].BillID);
                    if (bill != null)
                    {
                        if (e.Column == colQty)
                            e.Value = bill.Sum(o => o.数量);
                    }
                }
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBillNo.Text.Trim()) )
            {
                List<PaymentBillHd> bills = ((List<PaymentBillHd>)MainForm.dataSourceList[typeof(List<PaymentBillHd>)]).OrderBy(o => o.BillNo).ToList();
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
                                MainForm.itemDetailPageList[MainMenuConstants.PaymentBill].setNavButtonStatus(MainForm.mainMenuList[MainMenuConstants.PaymentBill], ButtonType.btnSave);
                            else
                                MainForm.itemDetailPageList[MainMenuConstants.PaymentBill].setNavButtonStatus(MainForm.mainMenuList[MainMenuConstants.PaymentBill], ButtonType.btnAudit);
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
                List<PaymentBillHd> bills = ((List<PaymentBillHd>)MainForm.dataSourceList[typeof(List<PaymentBillHd>)]).OrderBy(o => o.BillNo).ToList();
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
                                MainForm.itemDetailPageList[MainMenuConstants.PaymentBill].setNavButtonStatus(MainForm.mainMenuList[MainMenuConstants.PaymentBill], ButtonType.btnSave);
                            else
                                MainForm.itemDetailPageList[MainMenuConstants.PaymentBill].setNavButtonStatus(MainForm.mainMenuList[MainMenuConstants.PaymentBill], ButtonType.btnAudit);
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
                    //if (col.FieldName == "单价")
                    //{
                    //    //未结余款
                    //    col.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    //    new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "单价", "未结余款:")});
                    //}
                }
                
                PrintSettingController psc = new PrintSettingController(printControl);

                //页眉 
                if (hd != null)
                {
                    psc.PrintCompany = MainForm.Company;
                    psc.PrintHeader = "供应商对账单";
                    psc.PrintSubTitle = MainForm.Contacts.Replace("\\r\\n", "\r\n");
                    psc.PrintLeftHeader = "付款单号：" + hd.BillNo + "\r\n"
                        //+ "付款日期：" + deBillDate.Text + "\r\n"
                        + "  供应商：" + lueBusinessContact.Text;
                    psc.PrintRightHeader = "开始日期：" + soa.Min(o => o.结算日期).Value.ToString("yyyy-MM-dd") + "\r\n"
                        + "结束日期：" + soa.Max(o => o.结算日期).Value.ToString("yyyy-MM-dd");// + "\r\n"
                        //+ "结算方式：" + luePOClear.Text;
                }
                //获取明细列表界面数据（筛选后数据）
                decimal billAMT = 0;
                List<VPaymentBillDtl> rDtl = new List<VPaymentBillDtl>();
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    if (gridView.GetRow(i) != null)
                        rDtl.Add((VPaymentBillDtl)gridView.GetRow(i));
                }
                billAMT = rDtl.Sum(o => o.LastPaidAMT.Value);
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
            #region #showreport
            XtraStatementOfAccountReport xr = new XtraStatementOfAccountReport();
            //SchedulerControlPrintAdapter scPrintAdapter =
            //    new SchedulerControlPrintAdapter(this.schedulerControl1);
            //xr.SchedulerAdapter = scPrintAdapter;            
            xr.SetReportDataSource(soam, soas, soab);
            xr.CreateDocument(true);
            xr.paramCompany.Value = MainForm.Company;
            xr.paramTitle.Value = "供应商结算表";
            xr.paramContacts.Value = MainForm.Contacts.Replace("\\r\\n", "\r\n");
            xr.paramBillNo.Value = hd.BillNo;
            xr.paramCustomer.Value = lueBusinessContact.Text;
            xr.paramStartDate.Value = soa.Min(o => o.结算日期).Value.ToString("yyyy-MM-dd");
            xr.parameEndDate.Value = soa.Max(o => o.结算日期).Value.ToString("yyyy-MM-dd");

            using (ReportPrintTool printTool = new ReportPrintTool(xr))
            {
                printTool.AutoShowParametersPanel = false;
                printTool.ShowRibbonPreviewDialog();
            }
            #endregion #showreport
            return null;
        }

        private void gridControl_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Custom)
            {
                if (e.Button.Tag.ToString() == "CheckAll")
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
            }
        }

        private void mePaidAMT_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (!string.IsNullOrEmpty(mePaidAMT.Text))
            {
                decimal totalAMT = 0;
                if (!string.IsNullOrEmpty(meTotalAMT.Text))
                    totalAMT = Convert.ToDecimal(meTotalAMT.EditValue.ToString());
                hd.UnPaidAMT = totalAMT - Convert.ToDecimal(e.NewValue);
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
                if (!string.IsNullOrEmpty(mePaidAMT.Text))
                    amt = Convert.ToDecimal(mePaidAMT.EditValue.ToString());
                hd.UnPaidAMT = Convert.ToDecimal(e.NewValue) - amt;
            }
        }

        private void gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            getCheckAMT();
        }
    }
}
