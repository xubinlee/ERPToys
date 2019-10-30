using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace USL
{
    public partial class XtraMaterialMRPReport : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraMaterialMRPReport()
        {
            InitializeComponent();
            //GroupField gf = new GroupField("货品大类", XRColumnSortOrder.Ascending);
            //((GroupHeaderBand)(this.DetailReportSFGoods.FindControl("GroupHeader1", true))).GroupFields.Add(gf);
        }

        public void SetReportDataSource(object rSFGoods, object rAssemble)
        {
            //this.DetailReportGoods.DataSource = rGoods;
            if (rSFGoods == null)
                this.DetailReportSFGoods.Visible = false;
            else
            {
                this.DetailReportSFGoods.Visible = true;
                this.DetailReportSFGoods.DataSource = rSFGoods;
            }
            if (rAssemble == null)
                this.DetailReportAssemble.Visible = false;
            else
            {
                this.DetailReportAssemble.Visible = true;
                this.DetailReportAssemble.DataSource = rAssemble;
            }
        }

    }
}
