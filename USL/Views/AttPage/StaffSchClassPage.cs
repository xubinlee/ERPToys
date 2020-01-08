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
using EDMX;
using CommonLibrary;
using Utility;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Data.Linq;
using DevExpress.XtraGrid.Views.WinExplorer;
using DevExpress.XtraGrid.Views.Layout;
using Utility.Interceptor;
using ClientFactory;

namespace USL
{
    public partial class StaffSchClassPage : DevExpress.XtraEditors.XtraUserControl, IItemDetail
    {
        private static BaseFactory baseFactory = LoggerInterceptor.CreateProxy<BaseFactory>();
        Guid focused;
        //List<UsersInfo> focusedUsers;
        List<StaffSchClass> staffSchClassList;
        public StaffSchClassPage()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            BindData(null);
        }

        public void BindData(object obj)
        {
            departmentBindingSource.DataSource = baseFactory.GetModelList<Department>();
            schClassBindingSource.DataSource = baseFactory.GetModelList<SchClass>();
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
            //focused = winExplorerView.GetFocusedDisplayText();
            //if (string.IsNullOrEmpty(focused))
            //    focused = winExplorerView.GetGroupRowDisplayText(winExplorerView.FocusedRowHandle);
            //focusedUsers = baseFactory.GetModelList<UsersInfo>().FindAll(o =>
            //    o.IsDel == false && (o.Code == focused || o.Dept == focused));
            //staffSchClassBindingSource.DataSource = staffSchClassList = GetStaffSchClass(focusedUsers);
            if (winExplorerView.GetFocusedRowCellValue(colID) != null)
            {
                focused = new Guid(winExplorerView.GetFocusedRowCellValue(colID).ToString());
                staffSchClassBindingSource.DataSource = staffSchClassList = baseFactory.GetModelList<StaffSchClass>().FindAll(o =>
                    o.DeptID == focused).OrderBy(o => o.SchSerialNo).ToList();
            }
        }

        //List<StaffSchClass> GetStaffSchClass(List<UsersInfo> users)
        //{
        //    List<StaffSchClass> sch = new List<StaffSchClass>();
        //    Hashtable hasSch = new Hashtable();
        //    foreach (UsersInfo user in users)
        //    {
        //        List<StaffSchClass> ssc = baseFactory.GetModelList<StaffSchClass>().FindAll(o =>
        //            o.UserID == user.ID).OrderBy(o => o.SchSerialNo).ToList();
        //        foreach (StaffSchClass  item in ssc)
        //        {
        //            if (hasSch[item.SchClassID] == null)
        //            {
        //                hasSch.Add(item.SchClassID, ssc);
        //                sch.Add(item);
        //            }
        //        }
        //    }
        //    return sch;
        //}

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
        //void PageRefresh()
        //{
        //    baseFactory.GetModelList<StaffSchClass>)] = BLLFty.Create<StaffSchClassBLL>().GetStaffSchClass();
        //    baseFactory.GetModelList<VStaffSchClass>)] = BLLFty.Create<StaffSchClassBLL>().GetVStaffSchClass();
        //    BindData();
        //    if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.StaffAttendance))
        //    {
        //        AttendanceSchedulingPage page = ClientFactory.itemDetailList[MainMenuEnum.StaffAttendance] as AttendanceSchedulingPage;
        //        page.PageRefresh();
        //    }
        //}

        public bool Save()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                Hashtable hasSch = new Hashtable();
                List<StaffSchClass> sscList = new List<StaffSchClass>();
                for (int i = staffSchClassList.Count - 1; i >= 0; i--)
                {
                    //if (staffSchClassList[i].UserID == null || staffSchClassList[i].UserID == Guid.Empty)
                    //{
                    //    XtraMessageBox.Show("请选择排班人员。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return false;
                    //}
                    if (staffSchClassList[i].SchClassID == null || staffSchClassList[i].SchClassID == Guid.Empty)
                    {
                        XtraMessageBox.Show("时段名称不能为空。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (hasSch[staffSchClassList[i].DeptID.ToString() + staffSchClassList[i].SchClassID.ToString()] == null)
                        hasSch.Add(staffSchClassList[i].DeptID.ToString() + staffSchClassList[i].SchClassID.ToString(), staffSchClassList[i]);
                    else
                    {
                        CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "时段名称不能重复。");
                        return false;
                    }
                    staffSchClassList[i].SchSerialNo = i;
                    StaffSchClass ssc = baseFactory.GetModelList<StaffSchClass>().FirstOrDefault(o =>
                            o.DeptID == focused && o.SchClassID == staffSchClassList[i].SchClassID);
                    if (ssc == null)
                    {
                        ssc = new StaffSchClass();
                        ssc.ID = Guid.NewGuid();
                    }
                    ssc.DeptID = focused;
                    ssc.SchClassID = staffSchClassList[i].SchClassID;
                    ssc.SchSerialNo = staffSchClassList[i].SchSerialNo;
                    sscList.Add(ssc);
                    //foreach (UsersInfo user in focusedUsers)
                    //{
                    //    StaffSchClass ssc = baseFactory.GetModelList<StaffSchClass>().FirstOrDefault(o =>
                    //        o.UserID == user.ID && o.SchClassID == staffSchClassList[i].SchClassID);
                    //    if (ssc==null)
                    //    {
                    //        ssc = new StaffSchClass();
                    //        ssc.ID = Guid.NewGuid();
                    //    }
                    //    ssc.UserID = user.ID;
                    //    ssc.SchClassID = staffSchClassList[i].SchClassID;
                    //    ssc.SchSerialNo = staffSchClassList[i].SchSerialNo;
                    //    sscList.Add(ssc);
                    //}
                }
                BLLFty.Create<StaffSchClassBLL>().Update(sscList, focused);
                //addNew = false;
                //刷新数据
                //PageRefresh();
                baseFactory.DataPageRefresh<StaffSchClass>();
                baseFactory.DataPageRefresh<VStaffSchClass>();
                CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "保存成功");
                return true;
            }
            catch (Exception ex)
            {
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
            throw new NotImplementedException();
        }

        public void Print()
        {
            throw new NotImplementedException();
        }

        private void layoutView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            Save();
            baseFactory.DataPageRefresh<VStaffSchClass>();
        }

        private void layoutView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            Save();
            baseFactory.DataPageRefresh<VStaffSchClass>();
        }

        private void layoutView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            LayoutView view = sender as LayoutView;
            List<StaffSchClass> list = ((BindingSource)view.DataSource).DataSource as List<StaffSchClass>;
            if (e.IsGetData && list != null && list.Count > 0 && list[e.ListSourceRowIndex] != null)
            {
                SchClass sch = baseFactory.GetModelList<SchClass>().Find(o => o.ID == list[e.ListSourceRowIndex].SchClassID);
                if (sch != null)
                {
                    if (e.Column == colStartTime)
                        e.Value = sch.StartTime;
                    if (e.Column == colEndTime)
                        e.Value = sch.EndTime;
                    if (e.Column == colLateMinutes)
                        e.Value = sch.LateMinutes;
                    if (e.Column == colEarlyMinutes)
                        e.Value = sch.EarlyMinutes;
                    if (e.Column == colCheckInStartTime)
                        e.Value = sch.CheckInStartTime;
                    if (e.Column == colCheckInEndTime)
                        e.Value = sch.CheckInEndTime;
                    if (e.Column == colCheckOutStartTime)
                        e.Value = sch.CheckOutStartTime;
                    if (e.Column == colCheckOutEndTime)
                        e.Value = sch.CheckOutEndTime;
                    if (e.Column == colColor)
                        e.Value = sch.Color;
                }
            }
        }

    }
}
