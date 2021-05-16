using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismThreadingTest.Core;
using PrismThreadingTest.Modules.B.Views;

namespace PrismThreadingTest.Module.B
{
    public class BModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public BModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.RightRegion, typeof(MessageListView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}