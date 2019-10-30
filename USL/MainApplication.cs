using System;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Services;
using Microsoft.Practices.CompositeUI.SmartParts;
//using Microsoft.Practices.ObjectBuilder;
using CABDevExpress.Workspaces;
using Microsoft.Practices.CompositeUI.Commands;
using DevExpress.XtraEditors.Repository;
using System.ComponentModel.Design;
using CommonLibrary;

namespace USL
{
    /// <summary>
    /// CAB主应用程序类
    /// </summary>
    public class MainApplication : CABDevExpress.XtraFormApplicationBase<WorkItem, MainForm>
    ////, IServiceContainer
    {

       
        /// <summary>
        /// 
        /// </summary>
        protected override void Start()
        {
            Application.Run(Shell);
        }
        
        //protected override void BeforeShellCreated()
        //{
        //    base.BeforeShellCreated();
           
        //    InitializeEnvironment();
        //}
        //protected override void AddBuilderStrategies(Microsoft.Practices.ObjectBuilder.Builder builder)
        //{

        //    //添加远程事件连接的Strategy
        //    //base.AddBuilderStrategies(builder);
        //    ////builder.Strategies.Add(new ServiceProxyStrategy(), BuilderStage.PreCreation);
        //    ////builder.Strategies.Add(PermissionStrategy.Instance, BuilderStage.PostInitialization);
        //   // builder.Strategies.Add(new LocalServiceProxyStrategy<ICPServiceHostAttribute>(), BuilderStage.PostInitialization);
            
        //}
        


     

        //void InitializeEnvironment()
        //{
        //    ////ClientHelper.SetApplicationContext();
        //    ////ServiceClient.AddClientService(typeof(IServiceContainer), this);
        //    ////RootWorkItem.Services.AddNew<LoginUserInfoService, ILoginUserInfoService>();
        //    ////RootWorkItem.Services.AddNew<DefaultDataFinderFactory, IDataFinderFactory>();
        //    ////RootWorkItem.Services.Remove<IModuleEnumerator>();
            
        //    ////RootWorkItem.Services.AddNew<ICP.Framework.ClientComponents.UIFramework.DefaultUIBuilder, ICP.Framework.ClientComponents.UIFramework.IUIBuilder>();
        //    ////Program.IncreaseProgressBar(20);
        //}
        private void OnSmartPartActivated(object sender, WorkspaceEventArgs e)
        {
            Control control = (Control)e.SmartPart;
            if (control != null)
            {

                control = control.FindForm();
                Shell.ErrorListControl.CurrentOwner = control;
                Shell.ErrorListControl.FilterAll(control);
            }
        }
        private void OnSmartPartClosing(object sender, WorkspaceCancelEventArgs e)
        {
            Control control = (Control)e.SmartPart;

            if (control != null)
            {
                Shell.ErrorListControl.RemoveAll(control);

            }
        }
        private void OnSmartPartClosed(object sender, WorkspaceEventArgs e)
        {
            Control control = (Control)e.SmartPart;
            control.Dispose();
            control = null;
            this.Shell.PerformLayout();
        }
   

        protected override void AfterShellCreated()
        {
            
            base.AfterShellCreated();
            
            AddClientService();
            ////RootWorkItem.UIExtensionSites.RegisterSite("menu", Shell.menu);
            ////RootWorkItem.UIExtensionSites.RegisterSite("toolbar", Shell.tools);
            ////RootWorkItem.UIExtensionSites.RegisterSite("statusbar", Shell.status);

            ////ICommandAdapterMapService mapService = RootWorkItem.Services.Get<ICommandAdapterMapService>();
            ////mapService.Register(typeof(RepositoryItem), typeof(RepositoryItemCommandAdapter));

            ////ICP.Framework.ClientComponents.Controls.TabbedMdiWorkspace wp = new ICP.Framework.ClientComponents.Controls.TabbedMdiWorkspace(Shell);

////            wp.SmartPartActivated += this.OnSmartPartActivated;

////            wp.SmartPartClosing += this.OnSmartPartClosing;

////            wp.SmartPartClosed += this.OnSmartPartClosed;
            

////            RootWorkItem.Workspaces.Add(wp, "MainWorkspace");

////            this.RootWorkItem.Activated += new EventHandler(RootWorkItem_Activated);

            
////            Program.SetInitialState(LocalData.IsEnglish ? "Load application module..." : "加载应用模块...");

////            //下载模块信息
////            ClientPermission cp = new ClientPermission();
////            RootWorkItem.Services.Add<IModuleEnumerator>(cp);
////            foreach (UICommand command in cp.Commands)
////            {
////#if DEBUG
////                //#warning 此处极其危险，因为经常会以Debug环境编译dll并发布
////                //command.HasPermission = true;
////#endif
////                IElementBuilder builder = UIElementFactory.GetBuilder(command);
////                builder.BuildIn(RootWorkItem);
////            }
////            ShowPortal();
           
////            Program.IncreaseProgressBar(20);
            
////            this.Shell.TopMost = true;
////            this.Shell.TopMost = false;

        }

       
        private void ShowPortal()
        {
            ////PortalFactory factory = this.RootWorkItem.Items.AddNew<PortalFactory>(typeof(PortalFactory).ToString());
            ////factory.ShowPortal(LocalData.PortalType);
        }
     
        void RootWorkItem_Activated(object sender, EventArgs e)
        {
            ////Program.IncreaseProgressBar(20);
            ////Program.CloseLoginForm();
        }

        void AddClientService()
        {

            ////DockManagerWorkspace dockWP = new DockManagerWorkspace(Shell.dockManager1);
            ////RootWorkItem.Workspaces.Add(dockWP, "DockWorkspace");
            ////RootWorkItem.Workspaces.AddNew<CABDevExpress.Workspaces.XtraWindowWorkspace>("WindowWorkspace");
            
            
            ////RootWorkItem.Services.Add<IStatusbar>(Shell);
            ////RootWorkItem.Services.AddNew<DataUIManageService, IDataUIManageService>();
            ////RootWorkItem.Services.Add<IToolbar>(Shell);
            ////RootWorkItem.Services.Add<IMainMenu>(Shell);
            ////RootWorkItem.Services.Add<IMainForm>(Shell);
            
            ////RootWorkItem.Services.Add<IErrorTraceService>(Shell.ErrorListControl);
            ////RootWorkItem.Services.AddNew<DataFindClientService, IDataFindClientService>();
            ////RootWorkItem.Services.AddNew<BusinessInfoProviderFactory, IBusinessInfoProviderFactory>();
            CommonServices.ErrorTrace = (IErrorTraceService)Shell.ErrorListControl;
            CommonServices.Statusbar = (IStatusbar)Shell;
            CommonServices.ToolBar = (IToolbar)Shell;

           

        }



        #region IServiceContainer 成员

        //T IServiceContainer.GetService<T>()
        //{
        //    return (T)RootWorkItem.Services.Get(typeof(T));
        //}

        //object IServiceContainer.GetService(Type type)
        //{
        //    return RootWorkItem.Services.Get(type);
        //}

    

        #endregion

    

    }
}
