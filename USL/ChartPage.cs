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
using System.Collections;
using Utility;
using DBML;
using DevExpress.XtraCharts;

namespace USL
{
    public partial class ChartPage : DevExpress.XtraEditors.XtraUserControl, IItemDetail
    {
        public DBML.MainMenu mainMenu;
        IList dataSource;
        List<Company> customers;
        List<Goods> goodsList;
        public ChartPage(DBML.MainMenu menu)
        {
            InitializeComponent();
            mainMenu = menu;
            BindData(null);
        }

        public void BindData(object obj)
        {
            //if (mainMenu.Name==MainMenuConstants.AnnualSalesSummaryByCustomerReport)
            //    dataSource = MainForm.dataSourceList[typeof(List<AnnualSalesSummaryByCustomerReport>)] as IList;
            //else if (mainMenu.Name == MainMenuConstants.AnnualSalesSummaryByGoodsReport)
            //    dataSource = MainForm.dataSourceList[typeof(List<AnnualSalesSummaryByGoodsReport>)] as IList;
            customers = MainForm.dataSourceList[typeof(List<Company>)] as List<Company>;
            goodsList = MainForm.dataSourceList[typeof(List<Goods>)] as List<Goods>;
            BindChart();
        }

        void BindChart()
        {
            chartControl1.Series.Clear();
            if (mainMenu.Name == MainMenuConstants.AnnualSalesSummaryByCustomerReport)
            {
                foreach (Company item in customers)
                {
                    // 柱状图里的第一个柱 
                    Series series = new Series(item.Name, ViewType.Bar3D);
                    dataSource = ((List<AnnualSalesSummaryByCustomerReport>)MainForm.dataSourceList[typeof(List<AnnualSalesSummaryByCustomerReport>)]).FindAll(o =>
                        o.客户代码 == item.Code);
                    series.DataSource = dataSource;
                    series.ArgumentScaleType = ScaleType.Qualitative;
                    series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                    series.CheckedInLegend = false;

                    // 以哪个字段进行显示 
                    series.ArgumentDataMember = "年份";
                    series.ValueScaleType = ScaleType.Numerical;

                    // 柱状图里的柱的取值字段 
                    series.ValueDataMembers.AddRange(new string[] { "金额" });
                    chartControl1.Series.Add(series);
                }
            }
            //else if (mainMenu.Name == MainMenuConstants.AnnualSalesSummaryByGoodsReport)
            //{
            //    foreach (Goods item in goodsList)
            //    {
            //        // 柱状图里的第一个柱 
            //        Series series = new Series(item.Name, ViewType.Bar3D);
            //        dataSource = ((List<AnnualSalesSummaryByGoodsReport>)MainForm.dataSourceList[typeof(List<AnnualSalesSummaryByGoodsReport>)]).FindAll(o =>
            //            o.货号 == item.Code);
            //        series.DataSource = dataSource;
            //        series.ArgumentScaleType = ScaleType.Qualitative;
            //        series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            //        //series.CheckedInLegend = false;

            //        // 以哪个字段进行显示 
            //        series.ArgumentDataMember = "年份";
            //        series.ValueScaleType = ScaleType.Numerical;

            //        // 柱状图里的柱的取值字段 
            //        series.ValueDataMembers.AddRange(new string[] { "金额" });
            //        chartControl1.Series.Add(series);
            //    }
            //}
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
            throw new NotImplementedException();
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
    }
}
