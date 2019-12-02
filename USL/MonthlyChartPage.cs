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
    public partial class MonthlyChartPage : DevExpress.XtraEditors.XtraUserControl, IItemDetail
    {
        IList dataSource;
        Hashtable hasSeries = new Hashtable();
        public MonthlyChartPage()
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
            BindData(null);
        }

        public void BindData(object obj)
        {
            GetYearMonthList();
            GetDataSource();
        }

        void GetYearMonthList()
        {
            List<SalesSummaryMonthlyReport> report = ((List<SalesSummaryMonthlyReport>)MainForm.dataSourceList[typeof(List<SalesSummaryMonthlyReport>)]).OrderBy(o => o.年月).ToList();
            Hashtable ht = new Hashtable();
            clbYearMonth.Items.Clear();
            foreach (SalesSummaryMonthlyReport item in report)
            {
                if (ht[item.年月] == null)
                {
                    ht.Add(item.年月, item.年月);
                    clbYearMonth.Items.Add(item.年月);
                }
            }
        }

        void GetDataSource()
        {
            foreach (CheckedListBoxItem item in clbYearMonth.Items)
            {
                if (item.CheckState == CheckState.Checked)
                {
                    if (hasSeries[item.Value.ToString()] == null)
                        hasSeries.Add(item.Value.ToString(), AddChartSeries(item.Value.ToString()));
                }
                else
                {
                    if (hasSeries[item.Value.ToString()] != null)
                    {
                        chartControl1.Series.Remove((Series)hasSeries[item.Value.ToString()]);
                        hasSeries.Remove(item.Value.ToString());
                    }
                }
            }
        }

        Series AddChartSeries(string yearMonth)
        {
            // 柱状图里的第一个柱 
            Series series = null;
            if (MainForm.Company.Contains("镇阳"))
                series = new Series(yearMonth, ViewType.Bar);
            else
                series = new Series(yearMonth, ViewType.Bar3D);
            dataSource = ((List<SalesSummaryMonthlyReport>)MainForm.dataSourceList[typeof(List<SalesSummaryMonthlyReport>)]).FindAll(o =>
                    o.年月 == yearMonth);
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
                DBML.MainMenu mm = ((List<DBML.MainMenu>)MainForm.dataSourceList[typeof(List<DBML.MainMenu>)]).FirstOrDefault(o => o.Name == MainMenuConstants.SalesSummaryMonthlyReport);
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
            GetDataSource();
        }

        private void btnUnCheckAll_Click(object sender, EventArgs e)
        {
            clbYearMonth.UnCheckAll();
        }

    }
}
