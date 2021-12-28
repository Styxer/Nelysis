using Events;
using Nelysis.Popup;
using Nelysis.Services;
using Nelysis.Services.Interfaces;
using Nelysis.Views;
using NetworkDashboard;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace Nelysis
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
            containerRegistry.RegisterSingleton<IFileService, FileService>();

            containerRegistry.RegisterDialog<NotificationDialog, NotificationDialogViewModel>();

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<EventsViewModule>();
            moduleCatalog.AddModule<NetworkDashboardModule>();
        }
    }
}
