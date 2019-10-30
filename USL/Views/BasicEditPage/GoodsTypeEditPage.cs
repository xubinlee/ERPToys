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
    public partial class GoodsTypeEditPage : DevExpress.XtraEditors.XtraUserControl, IDataEdit
    {
        GoodsType goodsType = null;

        public GoodsTypeEditPage(Object obj)
        {
            InitializeComponent();
            if (obj == null)
                goodsTypeBindingSource.DataSource = new GoodsType();
            else
            {
                goodsTypeBindingSource.DataSource = obj;
                goodsType = (GoodsType)obj;
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
                GoodsType obj = goodsTypeBindingSource.DataSource as GoodsType;
                obj.Code = Rexlib.GetSpellCode(obj.Name);
                //添加
                if (goodsType == null)
                {
                    goodsType = obj;
                    goodsType.ID = Guid.NewGuid();
                    BLLFty.Create<GoodsTypeBLL>().Insert(goodsType);

                }
                else
                    BLLFty.Create<GoodsTypeBLL>().Update(obj);
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
            goodsType = null;
            goodsTypeBindingSource.DataSource = new GoodsType();
            txtCode.Focus();
        }
    }
}
