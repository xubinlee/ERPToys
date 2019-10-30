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
using Factory;
using BLL;
using CommonLibrary;
using Utility;

namespace USL
{
    public partial class DeptEditPage : DevExpress.XtraEditors.XtraUserControl, IDataEdit
    {
        Department dept = null;
        public DeptEditPage(Object obj)
        {
            InitializeComponent();
            if (obj == null)
            {
                departmentBindingSource.DataSource = new Department();
            }
            else
            {
                departmentBindingSource.DataSource = obj;
                dept = (Department)obj;
            }
        }

        public void Add()
        {
            Clear();
        }

        public bool Save()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                Department obj = departmentBindingSource.DataSource as Department;
                obj.Code = Rexlib.GetSpellCode(obj.Name);
                //添加
                if (dept == null)
                {
                    dept = obj;
                    dept.ID = Guid.NewGuid();
                    dept.AddTime = DateTime.Now;
                    if (((List<Department>)MainForm.dataSourceList[typeof(List<Department>)]).Exists(o => o.Name == dept.Name))
                    {
                        XtraMessageBox.Show("该部门已经存在，不能重复添加。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    BLLFty.Create<DepartmentBLL>().Insert(dept);
                }
                else//修改
                    BLLFty.Create<DepartmentBLL>().Update(obj);
                //CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "保存成功");
                return true;
            }
            catch (Exception ex)
            {
                //CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), ex.Message);
                XtraMessageBox.Show(ex.Message, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        public void Clear()
        {
            dept = null;
            departmentBindingSource.DataSource = new Department();
            txtCode.Focus();
        }
    }
}
