using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraEditors.Repository;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.Data.Filtering;
using IBase;
using Utility;

namespace USL
{
    public partial class HistoryQueryForm : DevExpress.XtraEditors.XtraForm
    {
        DBML.MainMenu mainMenu;
        object dataSource;
        String filter = string.Empty;

        public String Filter
        {
            get { return filter; }
            //set { filter = value; }
        }
        public HistoryQueryForm(DBML.MainMenu menu, object source)
        {
            InitializeComponent();
            mainMenu = menu;
            dataSource = source;
        }

        private void HistoryQueryForm_Load(object sender, EventArgs e)
        {
            CreateFilterColumns();
            filterControl.CreateCriteriaByDefaultColumn();
        }

        private void CreateFilterColumns()
        {
            if (mainMenu.Name.Contains("Report") && mainMenu.Name != MainMenuConstants.SalesBillSummaryReport)
            {
                UnboundFilterColumn billDate = new UnboundFilterColumn("单据日期", "单据日期", typeof(String), new RepositoryItemDateEdit(), FilterColumnClauseClass.DateTime);
                filterControl.FilterColumns.Add(billDate);
            }
            else
                filterControl.SourceControl = dataSource;
            //filterControl.FilterColumns.Add(new UnboundFilterColumn("Age", "Field2", typeof(int), new RepositoryItemSpinEdit(), FilterColumnClauseClass.Generic));
        }

        private void filterControl_FilterChanged(object sender, FilterChangedEventArgs e)
        {
            lblFilterCriteria.Text = filterControl.FilterCriteria.LegacyToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            filter = CriteriaToWhereClauseHelper.GetMsSqlWhere(filterControl.FilterCriteria);
            this.Close();
        }
    }
}