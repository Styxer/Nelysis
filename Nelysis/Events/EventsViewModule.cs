using Events.Views;
using Nelysis.Core;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Events
{
    public class EventsViewModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public EventsViewModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "EventsView");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<EventsView>();
        }
    }
}