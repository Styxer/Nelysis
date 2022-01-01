using Events.ViewModels;
using Nelysis.Core;
using Nelysis.Core.Models;
using Nelysis.Core.Mvvm;
using Nelysis.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NetworkDashboard.ViewModels
{
    public class NetworkDashboardViewModel : RegionViewModelBase
    {

        #region Services
        private readonly IFileService<NetworkComponent> _fileService;
        private readonly IDialogService _dialogService;
        #endregion

        #region Commands
        public DelegateCommand ClickCmd { get; private set; }
        public DelegateCommand<string> OrderByCmd { get; private set; }
        #endregion

        #region Properties
        private ObservableCollection<NetworkComponent> _networkComponents;
        public ObservableCollection<NetworkComponent> NetworkComponents
        {
            get { return _networkComponents; }
            set { SetProperty(ref _networkComponents, value); }
        }

        private NetworkComponent _selectedItem;
        public NetworkComponent SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }       

        ///
        public ICollectionView NetworkComponentCollectionView { get; }
        private string _networkComponentFilter = string.Empty;
        public string NetworkComponentFilter
        {
            get { return _networkComponentFilter; }
            set { SetProperty(ref _networkComponentFilter, value); NetworkComponentCollectionView.Refresh(); }
        }

        #endregion

        #region private props
        private readonly EventsViewModel _vm;
        #endregion

        #region Ctor
        public NetworkDashboardViewModel(IRegionManager regionManager, IFileService<NetworkComponent> fileService, IDialogService dialogService, EventsViewModel vm)
           : base(regionManager)
        {

            ClickCmd = new DelegateCommand(ClickExecute);
            OrderByCmd = new DelegateCommand<string>(OrderByExecute);

            _fileService = fileService;
            _dialogService = dialogService;


            _networkComponents = new ObservableCollection<NetworkComponent>
                (_fileService.ProcessReadAsync(Paths.NetworkComponentsPath)
               .OrderBy(x => x.TotalDayThroughput));
            _dialogService = dialogService;

            _vm = vm;

            Collections.networkComponents = _networkComponents;

            _networkComponents.CollectionChanged += _networkComponents_CollectionChanged;

            NetworkComponentCollectionView = CollectionViewSource.GetDefaultView(_networkComponents);
            NetworkComponentCollectionView.Filter = FilterNetworkComponent;
     

        } 
        #endregion

        ~NetworkDashboardViewModel()
        {
            _networkComponents.CollectionChanged -= _networkComponents_CollectionChanged;
        }

        private bool FilterNetworkComponent(object obj)
        {
            if (obj is NetworkComponent networkComponent)
            {
                return networkComponent.IPAddress.Contains(NetworkComponentFilter, StringComparison.InvariantCultureIgnoreCase);
                    
            }

            return false;
        }

        //

        private void _networkComponents_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Collections.networkComponents = _networkComponents;
        }

        private void OrderByExecute(string headerName)
        {
            
            //TOOD: NOT HARD CODED NAMES
            if(headerName == "ID")
            {
                NetworkComponents = new ObservableCollection<NetworkComponent>(NetworkComponents.OrderBy(x => x.ID));
            }
            else if (headerName == "IP Address")
            {
                NetworkComponents = new ObservableCollection<NetworkComponent>(NetworkComponents.OrderBy(x => x.IPAddress));
            }

        }

        private void ClickExecute()
        {
            //throw new NotImplementedException();
            var dialogParameters = new DialogParameters
            {
               {"message", _selectedItem}
            };
            _dialogService.ShowDialog("NotificationDialog", dialogParameters, r =>
            {
                if (r.Result == ButtonResult.OK)
                {

                }
                else
                {

                }               
            });
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //TODO: BETTER SOLUTION
            foreach (var networkComponent in _networkComponents)
            {
                var targetEvents = _vm.Events.Where(x => x.IPAddress == networkComponent.IPAddress && x.MAC == networkComponent.MAC);
                foreach (var item in targetEvents)
                {
                    networkComponent.HasRelatedEvent = true;
                }
            }
        }        
    }
}
