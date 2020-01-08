#region Note
/*
{**************************************************************************************************************}
{  This file is automatically created when you open the Scheduler Control smart tag                            }
{  *and click Create Customizable Appointment Dialog.                                                          }
{  It contains a a descendant of the default appointment editing form created by visual inheritance.           }
{  In Visual Studio Designer add an editor that is required to edit your appointment custom field.             }
{  Modify the LoadFormData method to get data from a custom field and fill your editor with data.              }
{  Modify the SaveFormData method to retrieve data from the editor and set the appointment custom field value. }
{  The code that displays this form is automatically inserted                                                  }
{  *in the EditAppointmentFormShowing event handler of the SchedulerControl.                                   }
{                                                                                                              }
{**************************************************************************************************************}
*/
#endregion Note

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using EDMX;
using Utility;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using CommonLibrary;
using System.IO;
using System.Linq;
using Factory;
using BLL;
using Utility.Interceptor;
using ClientFactory;

namespace USL
{
    public partial class CustomAppointmentForm : DevExpress.XtraScheduler.UI.AppointmentForm
    {
        private static BaseFactory baseFactory = LoggerInterceptor.CreateProxy<BaseFactory>();
        private int PrevCheckedRow; // this is the selected row's handle
        object CheckedRow; // this is a DataRowView instance
        int CheckedRowIndex = -1;
        string WageDesignID = string.Empty;
        decimal? ManHour = 0;
        decimal? weight = 0;
        //decimal amt = 0;
        private Guid goodsID;
        string goodsName = string.Empty;
        //Appointments prevApt = null;  // 上次保存的记录
        public CustomAppointmentForm()
        {
            InitializeComponent();
        }
        public CustomAppointmentForm(DevExpress.XtraScheduler.SchedulerControl control, DevExpress.XtraScheduler.Appointment apt)
            : base(control, apt)
        {
            InitializeComponent();
        }
        public CustomAppointmentForm(DevExpress.XtraScheduler.SchedulerControl control, DevExpress.XtraScheduler.Appointment apt, bool openRecurrenceForm)
            : base(control, apt, openRecurrenceForm)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Add your code to obtain a custom field value and fill the editor with data.
        /// </summary>
        public override void LoadFormData(DevExpress.XtraScheduler.Appointment appointment)
        {
            goodsBindingSource.DataSource = baseFactory.GetModelList<Goods>().FindAll(o => o.Type.Equals((int)GoodsBigTypeEnum.Mold));
            wageDesignBindingSource.DataSource = baseFactory.GetModelList<WageDesign>();
            //if (appointment.CustomFields["UniqueID"] != null)
            //    prevApt = baseFactory.GetModelList<Appointments>().FirstOrDefault(o => o.UniqueID == (Int64)appointment.CustomFields["UniqueID"]);
            if (appointment.CustomFields["GoodsID"] == null)
            {
                lueGoods.EditValue = null;
            }
            else
            {
                goodsID = new Guid(appointment.CustomFields["GoodsID"].ToString());
                lueGoods.EditValue = goodsID;
            }
            //if (prevApt != null)
            //{
            //    if (prevApt.GoodsID == null)
            //        CheckedRowIndex = 0;
            //    else
            //        goodsID = prevApt.GoodsID.Value;
            //    ManHour = prevApt.ManHour;
            //    weight = prevApt.Weight;
            //    if (prevApt.WageDesignID == null)
            //        CheckedRowIndex = 0;
            //    else
            //    {
            //        WageDesignID = prevApt.WageDesignID.Value.ToString();
            //        CheckedRow = baseFactory.GetModelList<WageDesign>().Find(o => o.ID == new Guid(WageDesignID));
            //    }
            //    if (!string.IsNullOrEmpty(prevApt.Location))
            //        tbLocation.EditValue = decimal.Parse(prevApt.Location);
            //    lueGoods.EditValue = goodsID;
            //    seManHour.EditValue = ManHour;
            //    txtWeight.EditValue = weight;
            //}
            //else
            //    CheckedRowIndex = 0;
            if (appointment.CustomFields["ManHour"] != null)
                ManHour = decimal.Parse(appointment.CustomFields["ManHour"].ToString());
            seManHour.EditValue = ManHour;
            if (appointment.CustomFields["Weight"] != null)
                weight = decimal.Parse(appointment.CustomFields["Weight"].ToString());
            txtWeight.EditValue = weight;
            if (appointment.CustomFields["WageDesignID"] == null)
                CheckedRowIndex = 0;
            else
            {
                WageDesignID = appointment.CustomFields["WageDesignID"].ToString();
                CheckedRow = baseFactory.GetModelList<WageDesign>().Find(o => o.ID == new Guid(WageDesignID));
            }
            GetTotal();
            if (!string.IsNullOrEmpty(appointment.Location))
                tbLocation.EditValue = decimal.Parse(appointment.Location);
            edtShowTimeAs.SelectedIndex = int.Parse(appointment.StatusKey.ToString());
            //if (appointment.CustomFields["AMT"] != null)
            //{
            //    amt = decimal.Parse(appointment.CustomFields["AMT"].ToString());
            //    tbLocation.EditValue = amt;//AMT可手动修改，所以值以最后保存值为主
            //}
            base.LoadFormData(appointment);
        }
        /// <summary>
        /// Add your code to retrieve a value from the editor and set the custom appointment field.
        /// </summary>
        public override bool SaveFormData(DevExpress.XtraScheduler.Appointment appointment)
        {
            appointment.CustomFields["GoodsID"] = lueGoods.EditValue;
            appointment.CustomFields["WageDesignID"] = ((WageDesign)CheckedRow).ID;
            appointment.CustomFields["Wages"] = ((WageDesign)CheckedRow).Wages;
            appointment.CustomFields["ManHour"] = seManHour.Value;
            appointment.CustomFields["Weight"] = txtWeight.EditValue;
            appointment.CustomFields["NWeight"] = txtNWeight.EditValue;
            appointment.CustomFields["Cycle"] = txtCycle.EditValue;
            appointment.CustomFields["Price"] = ((WageDesign)CheckedRow).Price;
            appointment.CustomFields["ErrorRate"] = ((WageDesign)CheckedRow).ErrorRate;
            appointment.CustomFields["PlanYield"] = txtPlanYield.EditValue;
            appointment.CustomFields["Yielded"] = txtYielded.EditValue;
            appointment.CustomFields["AMT"] = tbLocation.EditValue;
            if (lueGoods.EditValue != null)  //修改净重和计算周期
            {
                Goods goods = baseFactory.GetModelList<Goods>().FirstOrDefault(o =>
                    o.ID == new Guid(lueGoods.EditValue.ToString()));
                if (goods != null && 
                    ((!string.IsNullOrEmpty(txtNWeight.Text) && goods.NWeight != decimal.Parse(txtNWeight.Text)) ||
                    (!string.IsNullOrEmpty(txtCycle.Text) && goods.Cycle != decimal.Parse(txtCycle.Text))))
                {
                    goods.NWeight = decimal.Parse(txtNWeight.Text);
                    goods.Cycle = decimal.Parse(txtCycle.Text);
                    BLLFty.Create<GoodsBLL>().Update(goods);
                }
            }
            return base.SaveFormData(appointment);
        }
        /// <summary>
        /// Add your code to notify that any custom field is changed. Return true if a custom field is changed, otherwise false.
        /// </summary>
        public override bool IsAppointmentChanged(DevExpress.XtraScheduler.Appointment appointment)
        {
            if (goodsID == (appointment.CustomFields["GoodsID"] == null ? Guid.Empty : new Guid(appointment.CustomFields["GoodsID"].ToString())) &&
                WageDesignID == appointment.CustomFields["WageDesignID"].ToString() &&
                ManHour == decimal.Parse(appointment.CustomFields["ManHour"].ToString()) &&
                weight == decimal.Parse(appointment.CustomFields["Weight"].ToString()))
                return false;
            else
                return true;
        }

        private void lueGoods_EditValueChanged(object sender, EventArgs e)
        {
            Goods goods = ((LookUpEdit)sender).GetSelectedDataRow() as Goods;
            if (goods != null)
            {
                goodsName = goods.Name;
                tbSubject.Text = goods.Name;
                txtNWeight.EditValue = goods.NWeight;
                txtCycle.EditValue = goods.Cycle;
                #region 处理图片
                if (!string.IsNullOrEmpty(lueGoods.Text))
                {
                    //将图片缩略图转为原图
                    if (!System.IO.Directory.Exists(MainForm.DownloadFilePath))
                        System.IO.Directory.CreateDirectory(MainForm.DownloadFilePath);
                    string fileName = MainForm.DownloadFilePath + String.Format("{0}.jpg", goods.Code);
                    if (!File.Exists(fileName))
                    {
                        string strErrorinfo = string.Empty;
                        FtpUpDown ftpUpDown = new FtpUpDown(MainForm.ServerUrl, MainForm.ServerUserName, MainForm.ServerPassword);
                        ftpUpDown.Download(MainForm.DownloadFilePath, String.Format("{0}.jpg", goods.Code), out strErrorinfo);
                    }
                    pePic.EditValue = ImageHelper.MakeBuff(Image.FromFile(fileName));
                    txtWeight.Enabled = true;
                    txtNWeight.Enabled = true;
                    txtCycle.Enabled = true;
                }
                else
                {

                    txtWeight.Enabled = false;
                    txtNWeight.Enabled = false;
                    txtCycle.Enabled = false;
                }
                #endregion
                GetTotal();
            }
        }

        private void txtWeight_EditValueChanged(object sender, EventArgs e)
        {
            GetTotal();
        }

        private void seManHour_EditValueChanged(object sender, EventArgs e)
        {
            GetTotal();
        }

        private void txtNWeight_EditValueChanged(object sender, EventArgs e)
        {
            GetTotal();
        }

        private void txtCycle_EditValueChanged(object sender, EventArgs e)
        {
            GetTotal();
        }

        void GetTotal()
        {
            ManHour = seManHour.Value;
            decimal wages = 0;
            decimal weight = 0;
            decimal nWeight = 0;
            decimal cycle = 0;
            int planYield = 0;
            int yielded = 0;
            if (!string.IsNullOrEmpty(txtWeight.Text))
                weight = decimal.Parse(txtWeight.Text);
            if (!string.IsNullOrEmpty(txtNWeight.Text))
                nWeight = decimal.Parse(txtNWeight.Text);
            if (!string.IsNullOrEmpty(txtCycle.Text))
                cycle = decimal.Parse(txtCycle.Text);
            if (CheckedRow != null)
            {
                if (ManHour == ((WageDesign)CheckedRow).ManHour)
                    wages = ((WageDesign)CheckedRow).Wages.Value;
                else
                {
                    //一班工时小于6（比如停电），工价按公班价格算
                    WageDesign obj = baseFactory.GetModelList<WageDesign>().Find(o => o.Name.Contains("公班"));
                    if (obj != null)
                        wages = obj.Wages.Value;
                }
                if (cycle != 0)
                {
                    planYield = Convert.ToInt32(ManHour * 3600 / cycle * ((WageDesign)CheckedRow).ErrorRate);
                    txtPlanYield.EditValue = planYield;
                }
                if (nWeight != 0)
                {
                    yielded = Convert.ToInt32(weight * 500 / nWeight);
                    txtYielded.EditValue = yielded;
                }
                if (((WageDesign)CheckedRow).Name.Contains("其他事项"))
                {
                    lueGoods.Enabled = false;
                    txtWeight.Enabled = false;
                    seManHour.Enabled = false;
                    txtNWeight.Enabled = false;
                    txtCycle.Enabled = false;
                    tbSubject.Enabled = true;
                    lueGoods.Text = null;
                    txtWeight.Text = null;
                    txtNWeight.Text = null;
                    txtCycle.Text = null;
                }
                else
                {
                    lueGoods.Enabled = true;
                    seManHour.Enabled = true;
                    tbSubject.Enabled = false;
                    if (((WageDesign)CheckedRow).Name.Contains("公班"))
                    {
                        tbLocation.EditValue = decimal.Round(Convert.ToDecimal(wages / ((WageDesign)CheckedRow).ManHour * ManHour), 2).ToString();
                        tbSubject.EditValue = "(公班)" + goodsName;

                    }
                    else if (((WageDesign)CheckedRow).Name.Contains("两") || ((WageDesign)CheckedRow).Name.Contains("二") || ((WageDesign)CheckedRow).Name.Contains("2"))
                    {
                        if (ManHour == ((WageDesign)CheckedRow).ManHour)
                            tbLocation.EditValue = ((WageDesign)CheckedRow).Wages.Value.ToString();
                        else
                        {
                            if (ManHour * 2 > ((WageDesign)CheckedRow).ManHour)//56+(工时*2-公班工时)*(80-56)/6
                                tbLocation.EditValue = decimal.Round(Convert.ToDecimal(wages + (ManHour * 2 - ((WageDesign)CheckedRow).ManHour) * ((((WageDesign)CheckedRow).Wages - wages) / ((WageDesign)CheckedRow).ManHour)), 2).ToString();
                            else//56/6*工时*2
                                tbLocation.EditValue = decimal.Round(Convert.ToDecimal(wages / ((WageDesign)CheckedRow).ManHour * ManHour) * 2, 2).ToString();
                        }
                        tbSubject.EditValue = "(两台机器)" + goodsName;
                    }
                    else if (((WageDesign)CheckedRow).Name.Contains("三") || ((WageDesign)CheckedRow).Name.Contains("3"))
                    {
                        if (ManHour == ((WageDesign)CheckedRow).ManHour)
                            tbLocation.EditValue = ((WageDesign)CheckedRow).Wages.Value.ToString();
                        else
                        {
                            if (ManHour * 3 > ((WageDesign)CheckedRow).ManHour)//56+(工时*3-公班工时)*(80-56)/6
                                tbLocation.EditValue = decimal.Round(Convert.ToDecimal(wages + (ManHour * 3 - ((WageDesign)CheckedRow).ManHour) * ((((WageDesign)CheckedRow).Wages - wages) / ((WageDesign)CheckedRow).ManHour)), 2).ToString();
                            else//56/6*工时*2
                                tbLocation.EditValue = decimal.Round(Convert.ToDecimal(wages / ((WageDesign)CheckedRow).ManHour * ManHour) * 3, 2).ToString();
                        }
                        tbSubject.EditValue = "(三台机器)" + goodsName;
                    }
                    else
                    {
                        if (ManHour == ((WageDesign)CheckedRow).ManHour)
                            tbLocation.EditValue = decimal.Round(Convert.ToDecimal((yielded - planYield) * ((WageDesign)CheckedRow).Price + wages), 2).ToString();
                        else
                            tbLocation.EditValue = decimal.Round(Convert.ToDecimal(wages / ((WageDesign)CheckedRow).ManHour * ManHour), 2).ToString();
                        tbSubject.EditValue = goodsName;
                    }
                }
            }
        }
        private void gridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column==colCheck)
            {
                if (e.IsGetData)
                {
                    if (CheckedRowIndex == -1 && !string.IsNullOrEmpty(WageDesignID))
                        CheckedRowIndex =gridView.LocateByDisplayText(gridView.FocusedRowHandle, colID, WageDesignID);
                    e.Value = (gridView.GetRow(e.ListSourceRowIndex) == gridView.GetRow(CheckedRowIndex));
                    gridView.FocusedRowHandle = CheckedRowIndex;
                    seManHour.Value = decimal.Parse(gridView.GetRowCellValue(CheckedRowIndex, colManHour).ToString());
                    CheckedRow = gridView.GetRow(CheckedRowIndex);
                    GetTotal();
                }
            }
        }

        private void gridView_Click(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            GridHitInfo hit = view.CalcHitInfo(view.GridControl.PointToClient(MousePosition));
            if (hit.InRowCell) //&& hit.Column==colCheck
                //&& hit.RowHandle != PrevCheckedRow)
            {
                //CheckedRow = view.GetRow(hit.RowHandle);
                CheckedRowIndex = hit.RowHandle;
                view.RefreshRow(PrevCheckedRow);
                PrevCheckedRow = hit.RowHandle;
                view.RefreshRow(PrevCheckedRow);
            }
        }

        private void pePic_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                if (pePic.EditValue != null && pePic.Image != null)
                {
                    ImageHelper.WindowsPhotoViewer(pePic.Image);
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
    }
}
