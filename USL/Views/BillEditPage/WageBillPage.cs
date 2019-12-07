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
using Utility.Interceptor;

namespace USL
{
    public partial class WageBillPage : DevExpress.XtraEditors.XtraUserControl, IItemDetail, IExtensions
    {
        private static ClientFactory clientFactory = LoggerInterceptor.CreateProxy<ClientFactory>();
        WageBillHd hd;
        List<VWageBillDtl> dtl;
        List<VAppointments> apt;
        Guid headID;

        public WageBillHd Hd
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

        public WageBillPage(Guid hdID)
        {
            InitializeComponent();
            gridView.ShowFindPanel();
            //设置合计列
            MainForm.SetSummaryItemColumns(gvAPT);
            headID = hdID;
            BindData(headID);
        }

        public void BindData(object hdID)
        {
            gridControl.BeginUpdate();
            if (hdID is Guid && ((Guid)hdID) != Guid.Empty)
            {
                headID = (Guid)hdID;
                wageBillHdBindingSource.DataSource = hd = BLLFty.Create<WageBillBLL>().GetWageBillHd(headID);
                dtl = BLLFty.Create<WageBillBLL>().GetVWageBillDtl().FindAll(o =>
                                    o.UserID == new Guid(lueBusinessContact.EditValue.ToString()));
                List<VWageBill> list = ((List<VWageBill>)MainForm.dataSourceList[typeof(List<VWageBill>)]).FindAll(o => o.HdID == headID);
                for (int i = dtl.Count - 1; i >= 0; i--)
                {
                    VWageBill obj = list.Find(o => o.年月 == dtl[i].YearMonth);
                    if (obj != null)
                    {
                        dtl[i].Welfare = obj.福利;
                        dtl[i].Deduction = obj.扣款;
                        dtl[i].SocialSecurity = obj.代扣社保;
                        dtl[i].IndividualIncomeTax = obj.代扣个税;
                    }
                    else
                        dtl.RemoveAt(i);
                }
                vWageBillDtlBindingSource.DataSource = dtl;
                vAppointmentsBindingSource.DataSource = apt =
                    ((List<VAppointments>)MainForm.dataSourceList[typeof(List<VAppointments>)]).FindAll(o =>
                        o.UserID == hd.UserID && (o.日期.Value.ToString("yyyy-MM").Equals(dtl.Min(m => m.YearMonth)) || o.日期.Value.ToString("yyyy-MM").Equals(dtl.Max(m => m.YearMonth))));
                decimal billAMT = dtl.Sum(o => o.AMT.Value);
                meLastAMT.EditValue = billAMT;
                meTotalAMT.EditValue = (hd.Balance == null ? 0 : hd.Balance) + billAMT;
            }
            vUsersInfoBindingSource.DataSource = ((List<VUsersInfo>)MainForm.dataSourceList[typeof(List<VUsersInfo>)]).FindAll(o => o.已删除 == false && o.部门 == "注塑机");
            gridView.BestFitColumns();
            gridView.FindFilterText = string.Empty;
            gridControl.EndUpdate();
        }

        public void Add()
        {
            wageBillHdBindingSource.DataSource = hd = new WageBillHd();
            vWageBillDtlBindingSource.DataSource = dtl = new List<VWageBillDtl>();
            hd.BillNo = MainForm.GetMaxBillNo(MainMenuConstants.WageBill, true).MaxBillNo;
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
                        WageBillHd dCheck = BLLFty.Create<WageBillBLL>().GetWageBillHd(hd.ID);
                        if (dCheck.Status == (int)BillStatus.UnAudited)
                            BLLFty.Create<WageBillBLL>().Delete(hd.ID);
                        else
                        {
                            CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "该单据已审核，不允许删除。");
                            return;
                        }

                    }
                    //刷新查询界面
                    clientFactory.DataPageRefresh<VWageBill>();
                    wageBillHdBindingSource.DataSource = hd = new WageBillHd();
                    vWageBillDtlBindingSource.DataSource = dtl = new List<VWageBillDtl>();
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
            if (string.IsNullOrEmpty(lueBusinessContact.Text.Trim()))
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "请填写职工信息");
                flag = false;
            }
            return flag;
        }

        public bool Save()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                gridView.CloseEditForm();
                hd = wageBillHdBindingSource.DataSource as WageBillHd;
                dtl = vWageBillDtlBindingSource.DataSource as List<VWageBillDtl>;
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
                List<VWageBillDtl> rDtl = new List<VWageBillDtl>();
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    if (gridView.GetRow(i) != null)
                        rDtl.Add((VWageBillDtl)gridView.GetRow(i));
                    
                }
                List<WageBillDtl> dtlList = new List<WageBillDtl>();
                bool errFlag = false;
                if (rDtl.Count == 0)
                {
                    errFlag = true;
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "请选择需要结算的单据信息");
                }
                foreach (VWageBillDtl item in rDtl)
                {
                    WageBillDtl obj = new WageBillDtl();
                    obj.ID = Guid.NewGuid();
                    obj.HdID = hd.ID;
                    obj.YearMonth = item.YearMonth;
                    obj.Wages = item.Wages.Value;
                    obj.Welfare = item.Welfare.Value;
                    obj.Deduction = item.Deduction.Value;
                    obj.SocialSecurity = item.SocialSecurity.Value;
                    obj.IndividualIncomeTax = item.IndividualIncomeTax.Value;
                    obj.AMT = item.AMT.Value;
                    dtlList.Add(obj);
                }
                if (errFlag)
                    return false;
                dtl = rDtl;
                //添加
                if (headID == Guid.Empty)
                {
                    //hd.ID = Guid.NewGuid();
                    BLLFty.Create<WageBillBLL>().Insert(hd, dtlList);
                }
                else//修改
                    BLLFty.Create<WageBillBLL>().Update(hd, dtlList);
                decimal billAMT = rDtl.Sum(o => o.AMT.Value);
                meLastAMT.EditValue = billAMT;
                meTotalAMT.EditValue = (hd.Balance == null ? 0 : hd.Balance) + billAMT;
                headID = hd.ID;
                vAppointmentsBindingSource.DataSource = apt =
                    ((List<VAppointments>)MainForm.dataSourceList[typeof(List<VAppointments>)]).FindAll(o =>
                        o.UserID == hd.UserID && (o.日期.Value.ToString("yyyy-MM").Equals(dtl.Min(m => m.YearMonth)) || o.日期.Value.ToString("yyyy-MM").Equals(dtl.Max(m => m.YearMonth))));
                //DataQueryPageRefresh();
                //QueryPageRefresh();
                clientFactory.DataPageRefresh<VWageBill>();
                //MainForm.BillSaveRefresh(MainMenuConstants.WageBillQuery);
                ////MainForm.DataQueryPageRefresh();
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
                    WageBillHd wage = BLLFty.Create<WageBillBLL>().GetWageBillHd(hd.ID);
                    dtl = BLLFty.Create<WageBillBLL>().GetVWageBillDtl().FindAll(o =>
                                        o.UserID == hd.UserID);

                    hd.Auditor = MainForm.usersInfo.ID;
                    hd.AuditDate = DateTime.Now;
                    hd.Status = 1;

                    List<Appointments> aptList = new List<Appointments>();
                    List<Alert> dellist = new List<Alert>();
                    foreach (VWageBillDtl item in dtl)
                    {
                        List<Appointments> apts = ((List<Appointments>)MainForm.dataSourceList[typeof(List<Appointments>)]).FindAll(o =>
                        o.UserID == hd.UserID && o.StartDate.Value.ToString("yyyy-MM").Equals(item.YearMonth));
                        if (wage != null && wage.Status == 1)  //取消审核
                        {
                            hd.Auditor = MainForm.usersInfo.ID;
                            hd.AuditDate = DateTime.Now;
                            hd.Status = 0;
                            foreach (Appointments a in apts)
                            {
                                a.WageStatus = (int)WageStatus.UnClosed;
                            }
                        }
                        else
                        {
                            foreach (Appointments a in apts)
                            {
                                a.WageStatus = (int)WageStatus.Closed;
                            }
                        }
                        aptList.AddRange(apts);
                        //删除提醒信息
                        //Alert alert = ((List<Alert>)MainForm.dataSourceList[typeof(List<Alert>)]).Find(o => o.BillID == item.BillID);
                        //if (alert != null)
                        //    dellist.Add(alert);
                    }
                    BLLFty.Create<WageBillBLL>().Audit(hd, aptList, dellist);
                    MainForm.SetAlertCount();

                    if (wage != null && wage.Status == 1)  //取消审核
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
                clientFactory.DataPageRefresh<VWageBill>();
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
                psc.PrintHeader = "工资结算单";
                psc.PrintSubTitle = MainForm.Contacts.Replace("\\r\\n", "\r\n");
                psc.PrintLeftHeader = "工资单号：" + hd.BillNo + "\r\n"
                    + "职工姓名：" + lueBusinessContact.Text;
                psc.PrintRightHeader = "结算日期：" + deBillDate.Text;// +"\r\n"
                    //+ "联系人：" + txtContacts.EditValue;
                //if (!string.IsNullOrEmpty(meRemark.Text))
                //    psc.PrintRightHeader = "备注：" + meRemark.Text;

                //页脚 
                psc.PrintLeftFooter = "制单人：" + lueMaker.Text + "  制单日期：" + deMakeDate.Text + "\r\n" 
                    + "审核人：" + lueAuditor.Text + "  审核日期：" + deAuditDate.Text; ;
                //psc.PrintFooter = "审核人：" + lueAuditor.Text + "  审核日期：" + deAuditDate.Text;

                //获取明细列表界面数据（筛选后数据）
                List<VWageBillDtl> rDtl = new List<VWageBillDtl>();
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    if (gridView.GetRow(i) != null)
                        rDtl.Add((VWageBillDtl)gridView.GetRow(i));
                }
                //金额转大写
                //gridView.Columns["YearMonth"].Summary.Clear();
                //gridView.Columns["YearMonth"].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                //        new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "金额", "合计金额:"+Rexlib.MoneyToUpper(rDtl.Sum(o=>o.AMT.Value)))});
            }
            //横纵向 
            //psc.LandScape = this.rbtnHorizon.Checked;
            psc.LandScape = MainForm.IsLandScape;

            //纸型 
            psc.PaperKind = MainForm.PrintPaperKind;
            psc.PaperSize = MainForm.PaperSize;
            //psc.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            //psc.PaperSize.Width = 216;
            //psc.PaperSize.Height = 140;
            //psc.PaperSize = new System.Drawing.Size(216, 140);
            //加载页面设置信息 
            psc.LoadPageSetting();

            psc.Preview();
        }

        private void lueBusinessContact_EditValueChanged(object sender, EventArgs e)
        {
            vWageBillDtlBindingSource.DataSource  = null;
            vWageBillDtlBindingSource.Clear();
            if (!string.IsNullOrEmpty(lueBusinessContact.Text.Trim()))
            {
                VUsersInfo user = ((LookUpEdit)sender).GetSelectedDataRow() as VUsersInfo;
                if (user != null && hd != null)
                {
                    hd.UserID = user.ID;
                    vWageBillDtlBindingSource.DataSource = BLLFty.Create<WageBillBLL>().GetVWageBillDtl().FindAll(o =>
                                                 o.UserID == new Guid(lueBusinessContact.EditValue.ToString()) && o.WageStatus == (int)WageStatus.UnClosed);
                }
            }
            else
                vWageBillDtlBindingSource.DataSource  = null;
            gridView.BestFitColumns();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBillNo.Text.Trim()))
            {
                List<WageBillHd> bills = ((List<WageBillHd>)MainForm.dataSourceList[typeof(List<WageBillHd>)]).OrderBy(o => o.BillNo).ToList();
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
                                MainForm.itemDetailPageList[MainMenuConstants.WageBill].setNavButtonStatus(MainForm.mainMenuList[MainMenuConstants.WageBill], ButtonType.btnSave);
                            else
                                MainForm.itemDetailPageList[MainMenuConstants.WageBill].setNavButtonStatus(MainForm.mainMenuList[MainMenuConstants.WageBill], ButtonType.btnAudit);
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
                List<WageBillHd> bills = ((List<WageBillHd>)MainForm.dataSourceList[typeof(List<WageBillHd>)]).OrderBy(o => o.BillNo).ToList();
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
                                MainForm.itemDetailPageList[MainMenuConstants.WageBill].setNavButtonStatus(MainForm.mainMenuList[MainMenuConstants.WageBill], ButtonType.btnSave);
                            else
                                MainForm.itemDetailPageList[MainMenuConstants.WageBill].setNavButtonStatus(MainForm.mainMenuList[MainMenuConstants.WageBill], ButtonType.btnAudit);
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
                DevExpress.XtraGrid.GridControl printControl = gcAPT;
                gcAPT.DataSource = apt;
                if (printControl == null || apt == null)
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "没有可打印的数据");
                    return;
                }
                //foreach (DevExpress.XtraGrid.Columns.GridColumn col in ((GridView)printControl.MainView).Columns)
                //{
                //    col.BestFit();
                //}
                
                PrintSettingController psc = new PrintSettingController(printControl);

                //页眉 
                if (hd != null)
                {
                    psc.PrintCompany = MainForm.Company;
                    psc.PrintHeader = "日程工资明细";
                    //psc.PrintSubTitle = MainForm.Contacts.Replace("\\r\\n", "\r\n");
                    psc.PrintLeftHeader = "工资单号：" + hd.BillNo + "\r\n"
                        + "职工姓名：" + lueBusinessContact.Text;
                    psc.PrintRightHeader = "开始日期：" + apt.Min(o => o.日期).Value.ToString("yyyy-MM-dd") + "\r\n"
                        + "结束日期：" + apt.Max(o => o.日期).Value.ToString("yyyy-MM-dd");
                }
                //获取明细列表界面数据（筛选后数据）
                decimal billAMT = 0;
                List<VWageBillDtl> rDtl = new List<VWageBillDtl>();
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    if (gridView.GetRow(i) != null)
                        rDtl.Add((VWageBillDtl)gridView.GetRow(i));
                }
                billAMT = rDtl.Sum(o => o.AMT.Value);
                psc.IsBill = false;
                if (hd.Balance != null)
                    psc.Balance = string.Format("上期结欠:{0:c}     共欠:{1:c}", hd.Balance, billAMT + hd.Balance);
                //横纵向 
                //psc.LandScape = this.rbtnHorizon.Checked;
                //if (MainForm.Company.Contains("镇阳"))
                //    psc.LandScape = false;
                //else
                    psc.LandScape = true;
                //纸型 
                psc.PaperKind = System.Drawing.Printing.PaperKind.A4;
                //加载页面设置信息 
                psc.LoadPageSetting();

                psc.Preview();
            }
            catch (Exception ex)
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "没有可打印的数据。\r\n错误信息：" + ex.Message);
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

        private void gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column==colWelfare ||
                e.Column ==colDeduction ||
                e.Column==colSocialSecurity ||
                e.Column==colIndividualIncomeTax)
            //AMT=Wages+Welfare-Abs(Deduction)-Abs(SocialSecurity)-Abs(IndividualIncomeTax)
            gridView.SetRowCellValue(e.RowHandle, colAMT, decimal.Round(Convert.ToDecimal(gridView.GetRowCellValue(e.RowHandle, colWages)) + Convert.ToDecimal(gridView.GetRowCellValue(e.RowHandle, colWelfare))
                            - Math.Abs(Convert.ToDecimal(gridView.GetRowCellValue(e.RowHandle, colDeduction))) - Math.Abs(Convert.ToDecimal(gridView.GetRowCellValue(e.RowHandle, colSocialSecurity))) - Math.Abs(Convert.ToDecimal(gridView.GetRowCellValue(e.RowHandle, colIndividualIncomeTax))), 2));
        }

        private void gvAPT_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "班次")
            {
                e.DisplayText = EnumHelper.GetDescription<WorkShiftsType>((WorkShiftsType)e.Value, false);
            }
            else if (e.Column.FieldName == "机号")
            {
                e.DisplayText = EnumHelper.GetDescription<MachineType>((MachineType)e.Value, false);
            }
        }
    }
}
