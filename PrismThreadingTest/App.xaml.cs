using Prism.Ioc;
using Prism.Modularity;
using PrismThreadingTest.Module.B;
using PrismThreadingTest.Modules.A;
using PrismThreadingTest.Views;
using System.Windows;


namespace PrismThreadingTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            moduleCatalog.AddModule<AModule>();
            moduleCatalog.AddModule<BModule>();
        }



    }
}
