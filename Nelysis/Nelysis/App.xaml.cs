using DryIoc;
using Events;
using Nelysis.Core.Models;
using Nelysis.Popup;
using Nelysis.Services;
using Nelysis.Services.Interfaces;
using Nelysis.Views;
using NetworkDashboard;
using NetworkDashboard.ViewModels;
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
            containerRegistry.RegisterSingleton<IFileService<NetworkComponent>, FileService<NetworkComponent>>();
            containerRegistry.RegisterSingleton<IFileService<Event>, FileService<Event>>();

            containerRegistry.RegisterDialog<NotificationDialog, NotificationDialogViewModel>();

            containerRegistry.RegisterSingleton(typeof(NetworkDashboardViewModel));

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<EventsViewModule>();
            moduleCatalog.AddModule<NetworkDashboardModule>();
        }
    }
}
