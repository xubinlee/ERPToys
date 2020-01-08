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
using EDMX;
using Factory;
using BLL;
using IBase;
using CommonLibrary;
using Utility;
using Utility.Interceptor;
using ClientFactory;

namespace USL
{
    public partial class CompanyEditPage : DevExpress.XtraEditors.XtraUserControl,IDataEdit
    {
        private static BaseFactory baseFactory = LoggerInterceptor.CreateProxy<BaseFactory>();
        Company company = null;
        List<TypesList> types;   //类型列表

        public CompanyEditPage(Object obj)
        {
            InitializeComponent();
            types = baseFactory.GetModelList<TypesList>();
            //单据类型
            typesListBindingSource.DataSource = EnumHelper.GetEnumValues<CustomerTypeEnum>(false);// types.FindAll(o => o.Type == TypesListConstants.CustomerType);
            if (obj == null)
            {
                companyBindingSource.DataSource = new Company();
            }
            else
            {
                companyBindingSource.DataSource = obj;
                company = (Company)obj;
            }
            if ((MainForm.Company.Contains("大正") || MainForm.Company.Contains("纸")))
                lciType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                
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
                Company obj = companyBindingSource.DataSource as Company;
                obj.Code = Rexlib.GetSpellCode(obj.Name);
                //添加
                if (company == null)
                {
                    company = obj;
                    company.ID = Guid.NewGuid();
                    company.AddTime = DateTime.Now;
                    bool exists = baseFactory.GetListByNoTracking<Company>().Any(o => o.ID != obj.ID && o.Name.Equals(company.Name));
                    if (exists)
                    {

                        XtraMessageBox.Show("该客户已经存在，不能重复添加。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    BLLFty.Create<CompanyBLL>().Insert(company);
                }
                else//修改
                    BLLFty.Create<CompanyBLL>().Update(obj);
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
            company = null;
            companyBindingSource.DataSource = new Company();
            txtCode.Focus();
        }
    }
}
