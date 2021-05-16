using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismThreadingTest.Core;
using PrismThreadingTest.Modules.A.Views;

namespace PrismThreadingTest.Modules.A
{
    public class AModule : IModule
    {
        private readonly IRegionManager _regionManager;
        public AModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.LeftRegion, typeof(MessageView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}