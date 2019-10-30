using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace USL
{
    public partial class XtraStatementOfAccountReport : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraStatementOfAccountReport()
        {
            InitializeComponent();
            GroupField gf = new GroupField("用料", XRColumnSortOrder.Ascending);
            ((GroupHeaderBand)(this.DetailReportSummary.FindControl("GroupHeader2", true))).GroupFields.Add(gf);
        }

        public void SetReportDataSource(object rMaterial, object rSummary, object rBasket)
        {
            this.DetailReportMaterial.DataSource = rMaterial;
            if (rSummary == null)
                this.DetailReportSummary.Visible = false;
            else
            {
                this.DetailReportSummary.Visible = true;
                this.DetailReportSummary.DataSource = rSummary;
            }
            this.DetailReportBasket.DataSource = rBasket;
        }

    }
}
