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
using System.Collections;
using CommonLibrary;
using Factory;
using BLL;
using Utility;

namespace USL
{
    public partial class SchClassPage : DevExpress.XtraEditors.XtraUserControl, IItemDetail
    {
        //bool addNew = false;
        List<SchClass> schClassList;
        public SchClassPage()
        {
            InitializeComponent();
            schClassBindingSource.DataSource = schClassList = MainForm.dataSourceList[typeof(List<SchClass>)] as List<SchClass>;
        }

        public void Add()
        {
            //schClassBindingSource.DataSource = schClassList = new List<SchClass>();
            layoutView.AddNewRow();
            //addNew = true;
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
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                Hashtable hasGoods = new Hashtable();
                //if (schClassList == null)
                //{
                //    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), string.Format("请完整填写{0}", dpBOM.Text.Trim()));
                //    return false;
                //}
                for (int i = schClassList.Count - 1; i >= 0; i--)
                {
                    if (string.IsNullOrEmpty(schClassList[i].Name) || schClassList[i].StartTime == null || schClassList[i].EndTime == null)
                    {
                        XtraMessageBox.Show("时段名称或时间不能为空。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (hasGoods[schClassList[i].Name] == null)
                        hasGoods.Add(schClassList[i].Name, schClassList[i]);
                    else
                    {
                        CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "时段名称不能重复。");
                        return false;
                    }
                    if (schClassList[i].ID == null || schClassList[i].ID == Guid.Empty)
                        schClassList[i].ID = Guid.NewGuid();
                    schClassList[i].SerialNo = i;
                    if (schClassList[i].CheckInStartTime == null)
                        schClassList[i].CheckInStartTime = schClassList[i].StartTime.Value.AddMinutes(-30);
                    if (schClassList[i].CheckInEndTime == null)
                        schClassList[i].CheckInEndTime = schClassList[i].StartTime.Value.AddMinutes(30);
                    if (schClassList[i].CheckOutStartTime == null)
                        schClassList[i].CheckOutStartTime = schClassList[i].EndTime.Value.AddMinutes(-30);
                    if (schClassList[i].CheckOutEndTime == null)
                        schClassList[i].CheckOutEndTime = schClassList[i].EndTime.Value.AddMinutes(30);
                }
                //添加
                //if (addNew)
                //{
                //    BLLFty.Create<SchClassBLL>().Insert(schClassList);
                //}
                //else//修改
                    BLLFty.Create<SchClassBLL>().Update(schClassList);
                //addNew = false;
                //DataQueryPageRefresh();
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
            MainForm.DataPageRefresh(MainMenuConstants.SchClass);
        }

        private void layoutView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            Save();
            MainForm.DataPageRefresh(MainMenuConstants.SchClass);
        }
    }
}
