using Nelysis.Core;
using Nelysis.Core.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace Nelysis.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region Cmd
        public DelegateCommand ClosingCmd { get; private set; }

        public DelegateCommand<string> ChangeScreenCmd { get; private set; }
        #endregion

        #region Properties
        private string _title = "Nelysis Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        #endregion

        #region Services
        private readonly IRegionManager _regionManager;
        #endregion

        #region Ctor
        public MainWindowViewModel(IRegionManager regionManager)
        {
            ClosingCmd = new DelegateCommand(ClosingExecute);
            ChangeScreenCmd = new DelegateCommand<string>(ChangeScreenExecute);
            _regionManager = regionManager;
        }

        #endregion
        #region Command Imp.
        private void ChangeScreenExecute(string screenName)
        {
            //TODO: REMOVE HARD CODED
            if (screenName == "Components Types")
            {
                _regionManager.RequestNavigate(RegionNames.ContentRegion, "NetworkDashboardView", NavigationCompleted);
            }
            else if (screenName == "Events")
            {
                _regionManager.RequestNavigate(RegionNames.ContentRegion, "EventsView", NavigationCompleted);
            }
        }

        private void NavigationCompleted(NavigationResult obj)
        {
            System.Diagnostics.Debug.WriteLine(obj.Error);
        }

        private void ClosingExecute()
        {
            //TODO: Delete temp folder?
        } 
        #endregion
    }
}
