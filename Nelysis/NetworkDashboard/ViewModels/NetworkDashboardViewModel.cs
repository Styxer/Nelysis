using Nelysis.Core;
using Nelysis.Core.Models;
using Nelysis.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkDashboard.ViewModels
{
    public class NetworkDashboardViewModel : BindableBase
    {

        private readonly IFileService _fileService;

        public DelegateCommand<NetworkComponents> ClickCmd { get; private set; }

        private ObservableCollection<NetworkComponents> _networkComponents;
        public ObservableCollection<NetworkComponents> NetworkComponents
        {
            get { return _networkComponents; }
            set { SetProperty(ref _networkComponents, value); }
        }

        private NetworkComponents _selectedItem;
        public NetworkComponents SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }

        public NetworkDashboardViewModel(IFileService fileService)
        {

            ClickCmd = new DelegateCommand<NetworkComponents>(Click);


            _fileService = fileService;
            _networkComponents = new ObservableCollection<NetworkComponents>
                (_fileService.ProcessReadAsync(Paths.networkComponents)
               .OrderBy(x => x.TotalDayThroughput));

        }

        private void Click(NetworkComponents networkComponents)
        {
            //throw new NotImplementedException();
        }



        //public ViewAViewModel()
        //{
        //    
        //}
    }
}
