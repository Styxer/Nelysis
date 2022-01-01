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

        public DelegateCommand<string> SearchCmd { get; private set; }
        #endregion

        #region Private Properties
        private string _selectedRegion; //TODO: NOT LIKE THIs
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

        private readonly NetworkDashboardViewModel _vm;
      
        
        #endregion

        #region Services
        private readonly IRegionManager _regionManager;
        #endregion

        #region Ctor
        public MainWindowViewModel(IRegionManager regionManager, NetworkDashboardViewModel vm)
        {


            ClosingCmd = new DelegateCommand(ClosingExecute);
            ChangeScreenCmd = new DelegateCommand(ChangeScreenExecute);
            SearchCmd = new DelegateCommand<string>(SearchExecute);


            _regionManager = regionManager;
            _networkComponentsScreen = true;
            _vm = vm;
            //cv = CollectionViewSource.GetDefaultView(_vm);
            //cv.Filter = Filterr;
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

        private void SearchExecute(string str)
        {

            if (_networkComponentsScreen)
            {
                _vm.NetworkComponentFilter = "100";
                
            }
            else if (_evetsScreen)
            {
               
            }
        }

        #endregion
    }
}
