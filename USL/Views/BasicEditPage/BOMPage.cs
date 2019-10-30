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
using DevExpress.XtraGrid.Views.WinExplorer;
using DevExpress.XtraGrid.Views.Layout;

namespace USL
{
    public partial class BOMPage : DevExpress.XtraEditors.XtraUserControl, IItemDetail
    {
        Guid focused;
        //List<UsersInfo> focusedUsers;
        List<StaffSchClass> staffSchClassList;
        public BOMPage()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            BindData();
        }

        public void BindData()
        {
            //departmentBindingSource.DataSource = MainForm.dataSourceList[typeof(List<Department>)];
            //schClassBindingSource.DataSource = MainForm.dataSourceList[typeof(List<SchClass>)] as List<SchClass>;
            GetDataSource();
        }

        private void winExplorerView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetDataSource();
        }

        private void winExplorerView_RowCountChanged(object sender, EventArgs e)
        {
            GetDataSource();
        }

        void GetDataSource()
        {
            //if (winExplorerView.GetFocusedRowCellValue(colID) != null)
            //{
            //    focused = new Guid(winExplorerView.GetFocusedRowCellValue(colID).ToString());
            //    staffSchClassBindingSource.DataSource = staffSchClassList = ((List<StaffSchClass>)MainForm.dataSourceList[typeof(List<StaffSchClass>)]).FindAll(o =>
            //        o.DeptID == focused).OrderBy(o => o.SchSerialNo).ToList();
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


        /// <summary>
        /// 刷新查询界面
        /// </summary>
        void PageRefresh()
        {
            MainForm.dataSourceList[typeof(List<StaffSchClass>)] = BLLFty.Create<StaffSchClassBLL>().GetStaffSchClass();
            MainForm.dataSourceList[typeof(List<VStaffSchClass>)] = BLLFty.Create<StaffSchClassBLL>().GetVStaffSchClass();
            BindData();
            if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.StaffAttendance))
            {
                AttendanceSchedulingPage page = MainForm.itemDetailList[MainMenuConstants.StaffAttendance] as AttendanceSchedulingPage;
                page.PageRefresh();
            }
        }

        public bool Save()
        {
            //try
            //{
            //    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            //    Hashtable hasSch = new Hashtable();
            //    List<StaffSchClass> sscList = new List<StaffSchClass>();
            //    for (int i = staffSchClassList.Count - 1; i >= 0; i--)
            //    {
            //        if (staffSchClassList[i].SchClassID == null || staffSchClassList[i].SchClassID == Guid.Empty)
            //        {
            //            XtraMessageBox.Show("时段名称不能为空。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return false;
            //        }
            //        if (hasSch[staffSchClassList[i].DeptID.ToString() + staffSchClassList[i].SchClassID.ToString()] == null)
            //            hasSch.Add(staffSchClassList[i].DeptID.ToString() + staffSchClassList[i].SchClassID.ToString(), staffSchClassList[i]);
            //        else
            //        {
            //            CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "时段名称不能重复。");
            //            return false;
            //        }
            //        staffSchClassList[i].SchSerialNo = i;
            //        StaffSchClass ssc = ((List<StaffSchClass>)MainForm.dataSourceList[typeof(List<StaffSchClass>)]).FirstOrDefault(o =>
            //                o.DeptID == focused && o.SchClassID == staffSchClassList[i].SchClassID);
            //        if (ssc == null)
            //        {
            //            ssc = new StaffSchClass();
            //            ssc.ID = Guid.NewGuid();
            //        }
            //        ssc.DeptID = focused;
            //        ssc.SchClassID = staffSchClassList[i].SchClassID;
            //        ssc.SchSerialNo = staffSchClassList[i].SchSerialNo;
            //        sscList.Add(ssc);
            //    }
            //    BLLFty.Create<StaffSchClassBLL>().Update(sscList, focused);
            //    //addNew = false;
            //    //刷新数据
            //    PageRefresh();
            //    CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "保存成功");
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), ex.Message);
            //    return false;
            //}
            //finally
            //{
            //    this.Cursor = System.Windows.Forms.Cursors.Default;
            //}
            return true;
        }

        public bool Audit()
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            throw new NotImplementedException();
        }

        private void layoutView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            Save();
            MainForm.DataPageRefresh(MainMenuConstants.BOM);
        }

        private void layoutView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            Save();
            MainForm.DataPageRefresh(MainMenuConstants.BOM);
        }

        private void layoutView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            //LayoutView view = sender as LayoutView;
            //List<StaffSchClass> list = ((BindingSource)view.DataSource).DataSource as List<StaffSchClass>;
            //if (e.IsGetData && list != null && list.Count > 0 && list[e.ListSourceRowIndex] != null)
            //{
            //    SchClass sch = ((List<SchClass>)MainForm.dataSourceList[typeof(List<SchClass>)]).Find(o => o.ID == list[e.ListSourceRowIndex].SchClassID);
            //    if (sch != null)
            //    {
            //        if (e.Column == colStartTime)
            //            e.Value = sch.StartTime;
            //        if (e.Column == colEndTime)
            //            e.Value = sch.EndTime;
            //        if (e.Column == colLateMinutes)
            //            e.Value = sch.LateMinutes;
            //        if (e.Column == colEarlyMinutes)
            //            e.Value = sch.EarlyMinutes;
            //        if (e.Column == colCheckInStartTime)
            //            e.Value = sch.CheckInStartTime;
            //        if (e.Column == colCheckInEndTime)
            //            e.Value = sch.CheckInEndTime;
            //        if (e.Column == colCheckOutStartTime)
            //            e.Value = sch.CheckOutStartTime;
            //        if (e.Column == colCheckOutEndTime)
            //            e.Value = sch.CheckOutEndTime;
            //        if (e.Column == colColor)
            //            e.Value = sch.Color;
            //    }
            //}
        }

    }
}
