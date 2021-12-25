using Nelysis.Core;
using NetworkDashboard.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace NetworkDashboard
{
    public class NetworkDashboardModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public NetworkDashboardModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "NetworkDashboardView");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NetworkDashboardView>();
        }
    }
}