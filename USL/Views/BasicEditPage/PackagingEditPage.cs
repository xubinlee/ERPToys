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

namespace USL
{
    public partial class PackagingEditPage : DevExpress.XtraEditors.XtraUserControl, IDataEdit
    {
        Packaging entity = null;
        public PackagingEditPage(Object obj)
        {
            InitializeComponent();
            if (obj == null)
                packagingBindingSource.DataSource = new Packaging();
            else
            {
                packagingBindingSource.DataSource = obj;
                entity = (Packaging)obj;
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
                Packaging obj = packagingBindingSource.DataSource as Packaging;
                //添加
                if (entity == null)
                {
                    entity = obj;
                    entity.ID = Guid.NewGuid();
                    BLLFty.Create<PackagingBLL>().Insert(entity);

                }
                else
                    BLLFty.Create<PackagingBLL>().Update(obj);
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
            entity = null;
            packagingBindingSource.DataSource = new Packaging();
            txtName.Focus();
        }
    }
}
