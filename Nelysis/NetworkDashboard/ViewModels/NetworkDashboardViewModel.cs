﻿using Events.ViewModels;
using Nelysis.Core;
using Nelysis.Core.Models;
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
    public class NetworkDashboardViewModel : BindableBase, INavigationAware
    {

        private readonly IFileService<NetworkComponent> _fileService;
        private readonly IDialogService _dialogService;

        public DelegateCommand<NetworkComponent> ClickCmd { get; private set; }

        public DelegateCommand<string> OrderByCmd { get; private set; }

        private ObservableCollection<NetworkComponent> _networkComponents;
        public ObservableCollection<NetworkComponent> NetworkComponents
        {
            get { return _networkComponents; }
            set { SetProperty(ref _networkComponents, value); }
        }

        //private NetworkComponent _selectedItem;
        //public NetworkComponent SelectedItem
        //{
        //    get { return _selectedItem; }
        //    set { SetProperty(ref _selectedItem, value); }
        //}

        ///
        public ICollectionView NetworkComponentCollectionView { get; }
        private string _employeesFilter = string.Empty;
        public string NetworkComponentFilter
        {
            get { return _employeesFilter; }
            set { SetProperty(ref _employeesFilter, value); }
        }
        


        public NetworkDashboardViewModel(IFileService<NetworkComponent> fileService, IDialogService dialogService, EventsViewModel vm)
        {

            ClickCmd = new DelegateCommand<NetworkComponent>(ClickExecute);

            OrderByCmd = new DelegateCommand<string>(OrderByExecute);


            _fileService = fileService;
            _dialogService = dialogService;

        
            _networkComponents = new ObservableCollection<NetworkComponent>
                (_fileService.ProcessReadAsync(Paths.NetworkComponentsPath)
               .OrderBy(x => x.TotalDayThroughput));
            _dialogService = dialogService;

     



            Collections.networkComponents = _networkComponents;

            _networkComponents.CollectionChanged += _networkComponents_CollectionChanged;

            ////
          
            NetworkComponentCollectionView = CollectionViewSource.GetDefaultView(_networkComponents);
            NetworkComponentCollectionView.Filter = FilterNetworkComponent;
          //  EmployeesCollectionView.GroupDescriptions.Add(new PropertyGroupDescription(nameof(NetworkComponent.IPAddress)));
            //EmployeesCollectionView.SortDescriptions.Add(new SortDescription(nameof(NetworkComponents.Name), ListSortDirection.Ascending));
            ///


        }


        private bool FilterNetworkComponent(object obj)
        {
            if (obj is NetworkComponent employeeViewModel)
            {
                return employeeViewModel.IPAddress.Contains(NetworkComponentFilter, StringComparison.InvariantCultureIgnoreCase);
                    
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

        private void ClickExecute(NetworkComponent networkComponents)
        {
            //throw new NotImplementedException();
            var dialogParameters = new DialogParameters
            {
               {"message", networkComponents}
            };
            _dialogService.ShowDialog("NotificationDialog", dialogParameters, r =>
            {
                if (r.Result == ButtonResult.OK)
                {

                }
                else
                {

                }
                //if (r.Result == ButtonResult.None)
                //   // Title = "Result is None";
                //else if (r.Result == ButtonResult.OK)
                //   // Title = "Result is OK";
                //else if (r.Result == ButtonResult.Cancel)
                //    Title = "Result is Cancel";
                //else
                //    Title = "I Don't know what you did!?";
            });
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //TODO: BETTER SOLUTION
            foreach (var networkComponent in _networkComponents)
            {
                var targetEvents = Collections.events.Where(x => x.IPAddress == networkComponent.IPAddress && x.MAC == networkComponent.MAC);
                foreach (var item in targetEvents)
                {
                    networkComponent.HasRelatedEvent = true;
                }
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }



        //public ViewAViewModel()
        //{
        //    
        //}
    }
}
