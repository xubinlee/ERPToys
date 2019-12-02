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
using Factory;
using BLL;
using DBML;
using CommonLibrary;
using Utility;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Data.Linq;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors.Controls;

namespace USL
{
    public partial class CustomerChartPage : DevExpress.XtraEditors.XtraUserControl, IItemDetail
    {
        IList dataSource;
        Hashtable hasSeries = new Hashtable();
        public CustomerChartPage()
        {
            InitializeComponent();
            chartControl1.Series.Clear();
            if (MainForm.Company.Contains("镇阳"))
            {
                btnRestoreDefaultAngles.Visible = false;
                icbo3DModle.Visible = false;
            }
            else
            {
                btnRestoreDefaultAngles.Visible = true;
                icbo3DModle.Visible = true;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            winExplorerView.ShowFindPanel();
            BindData(null);
        }

        public void BindData(object obj)
        {
            vBusinessContactBindingSource.DataSource = ((List<VCompany>)MainForm.dataSourceList[typeof(List<VCompany>)]);
            GetYearMonthList();
            GetDataSource(winExplorerView.GetFocusedDataSourceRowIndex());
        }

        void GetYearMonthList()
        {
            List<AnnualSalesSummaryByCustomerReport> report = ((List<AnnualSalesSummaryByCustomerReport>)MainForm.dataSourceList[typeof(List<AnnualSalesSummaryByCustomerReport>)]).OrderBy(o => o.年月).ToList();
            Hashtable ht = new Hashtable();
            clbYearMonth.Items.Clear();
            foreach (AnnualSalesSummaryByCustomerReport item in report)
            {
                if (ht[item.年月] == null)
                {
                    ht.Add(item.年月, item.年月);
                    clbYearMonth.Items.Add(item.年月);
                }
            }
        }

        private void winExplorerView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetDataSource(winExplorerView.GetFocusedDataSourceRowIndex());
        }

        private void winExplorerView_RowCountChanged(object sender, EventArgs e)
        {
                GetDataSource(winExplorerView.GetFocusedDataSourceRowIndex());
        }

        private void winExplorerView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colCheckBoxID)
                GetDataSource(winExplorerView.GetFocusedDataSourceRowIndex());
        }

        void GetDataSource(int rowIndex)//ROWINDEX废弃
        {
            hasSeries.Clear();
            chartControl1.Series.Clear();
            for (int i = winExplorerView.RowCount - 1; i >= 0; i--)
            {
                //if (winExplorerView.GetFocusedRowCellValue(colCheckBoxID) != null && winExplorerView.GetFocusedRowCellValue(col名称) != null)
                if (winExplorerView.GetRowCellValue(i, colCheckBoxID) != null && winExplorerView.GetRowCellValue(i, col名称) != null)
                {
                    //string customer = winExplorerView.GetFocusedRowCellValue(col名称).ToString();
                    //if (Convert.ToBoolean(winExplorerView.GetFocusedRowCellValue(colCheckBoxID)))
                    string customer = winExplorerView.GetRowCellValue(i, col名称).ToString();
                    if (Convert.ToBoolean(winExplorerView.GetRowCellValue(i, colCheckBoxID)))
                    {
                        if (hasSeries[customer] == null)
                            hasSeries.Add(customer, AddChartSeries(customer));
                    }
                    else
                    {
                        if (hasSeries[customer] != null)
                        {
                            chartControl1.Series.Remove((Series)hasSeries[customer]);
                            hasSeries.Remove(customer);
                        }
                    }
                }
            }
        }

        Series AddChartSeries(string customer)
        {
            // 柱状图里的第一个柱 
            Series series = null;
            if (MainForm.Company.Contains("镇阳"))
                series = new Series(customer, ViewType.Bar);
            else
                series = new Series(customer, ViewType.Bar3D);
            List<AnnualSalesSummaryByCustomerReport> dsList = new List<AnnualSalesSummaryByCustomerReport>();
            dataSource = null;
            foreach (CheckedListBoxItem item in clbYearMonth.Items)
            {
                if (item.CheckState == CheckState.Checked)
                {
                    AnnualSalesSummaryByCustomerReport obj = ((List<AnnualSalesSummaryByCustomerReport>)MainForm.dataSourceList[typeof(List<AnnualSalesSummaryByCustomerReport>)]).FirstOrDefault(o =>
                        o.客户名称 == customer && o.年月 == item.Value.ToString());
                    dsList.Add(obj);
                }
            }
            dataSource = dsList;
            series.DataSource = dataSource;
            series.ArgumentScaleType = ScaleType.Qualitative;
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series.CheckedInLegend = false;

            // 以哪个字段进行显示 
            series.ArgumentDataMember = "年月";
            series.ValueScaleType = ScaleType.Numerical;

            // 柱状图里的柱的取值字段 
            series.ValueDataMembers.AddRange(new string[] { "金额" });
            chartControl1.Series.Add(series);
            return series;
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
            throw new NotImplementedException();
        }

        public bool Audit()
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            try
            {
                
                PrintSettingController psc = new PrintSettingController(chartControl1);
                //页眉 
                psc.PrintCompany = MainForm.Company;
                DBML.MainMenu mm = ((List<DBML.MainMenu>)MainForm.dataSourceList[typeof(List<DBML.MainMenu>)]).FirstOrDefault(o =>
                    o.Name == MainMenuConstants.AnnualSalesSummaryByCustomerReport);
                if (mm != null)
                    psc.PrintHeader = mm.Caption;
                psc.PrintSubTitle = MainForm.Contacts.Replace("\\r\\n", "\r\n");
                //页脚 
                //psc.PrintRightFooter = "打印日期：" + DateTime.Now.ToString();

                psc.IsBill = false;

                //横纵向 
                //psc.LandScape = this.rbtnHorizon.Checked;
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

        protected virtual void UpdateRotationAngles(Diagram3D diagram)
        {
        }

        private void btnRestoreDefaultAngles_Click(object sender, EventArgs e)
        {
            Diagram3D diagram = chartControl1.Diagram as Diagram3D;
            if (diagram == null)
                return;
            diagram.RotationType = RotationType.UseAngles;
            UpdateRotationAngles(diagram);
            diagram.RotationType = RotationType.UseMouseAdvanced;
        }

        private void icbo3DModle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (icbo3DModle.SelectedIndex == -1)
                return;
            int bar3DModelIndex = icbo3DModle.SelectedIndex;
            Bar3DModel barModel = (Bar3DModel)bar3DModelIndex;
            foreach (Series series in chartControl1.Series)
            {
                Bar3DSeriesView seriesView = series.View as Bar3DSeriesView;
                if (seriesView != null)
                    seriesView.Model = barModel;
            }
            //checkEditShowFacet.Enabled = IsFacetEnabled(barModel);
        }

        private void clbYearMonth_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            GetDataSource(winExplorerView.GetFocusedDataSourceRowIndex());
            btnCustomerUnCheckAll_Click(sender, e);
        }

        private void btnYearMonthUnCheckAll_Click(object sender, EventArgs e)
        {
            clbYearMonth.UnCheckAll();
        }

        private void btnCustomerUnCheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < winExplorerView.RowCount; i++)
            {
                if (winExplorerView.GetRow(i) != null && Convert.ToBoolean(winExplorerView.GetRowCellValue(i, colCheckBoxID)))
                    winExplorerView.SetRowCellValue(i, colCheckBoxID, false);
                if (winExplorerView.GetRowCellValue(i, col名称) != null)
                GetDataSource(i);
            }
        }

    }
}
