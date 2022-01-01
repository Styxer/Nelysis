using Events.ViewModels;
using Nelysis.Core;
using Nelysis.Core.Models;
using NetworkDashboard.ViewModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace Nelysis.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region Cmd
        public DelegateCommand ClosingCmd { get; private set; }

        public DelegateCommand ChangeScreenCmd { get; private set; }

       
        #endregion

        #region Private Properties
       
        #endregion

        #region Properties
        private string _title = "Nelysis Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _networkComponentsScreen;
        public bool NetworkComponentsScreen
        {
            get { return _networkComponentsScreen; }
            set { SetProperty(ref _networkComponentsScreen, value); }
        }

        private bool _evetsScreen;
        public bool EvetsScreen
        {
            get { return _evetsScreen; }
            set { SetProperty(ref _evetsScreen, value); }
        }

        private string _filter;
        public string Filter
        {
            get { return _filter; }
            set
            { 
                SetProperty(ref _filter, value);
                if (_networkComponentsScreen)
                {
                    _networkDashboardVM.NetworkComponentFilter = value;

                }
                else if (_evetsScreen)
                {
                    _eventsVM.EventFilter = value;
                }

            }
        }

        private readonly NetworkDashboardViewModel _networkDashboardVM;
        private readonly EventsViewModel _eventsVM;

        #endregion

        #region Services
        private readonly IRegionManager _regionManager;
        #endregion

        #region Ctor
        public MainWindowViewModel(IRegionManager regionManager, NetworkDashboardViewModel networkDashboardVM, EventsViewModel eventsVM)
        {


            ClosingCmd = new DelegateCommand(ClosingExecute);
            ChangeScreenCmd = new DelegateCommand(ChangeScreenExecute);
            


            _regionManager = regionManager;
            _networkComponentsScreen = true;
            _networkDashboardVM = networkDashboardVM;
            _eventsVM = eventsVM;


        }

        #endregion
        #region Command Imp.
        private void ChangeScreenExecute()
        {          
           
            if (_networkComponentsScreen)
            {
                _regionManager.RequestNavigate(RegionNames.ContentRegion, "NetworkDashboardView");
            }
            else if (_evetsScreen)
            {
                _regionManager.RequestNavigate(RegionNames.ContentRegion, "EventsView");
            }
        }


        private void ClosingExecute()
        {
            //TODO: Delete temp folder?
        }

     

        #endregion
    }
}
