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
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace NetworkDashboard.ViewModels
{
    public class NetworkDashboardViewModel : BindableBase
    {

        private readonly IFileService _fileService;
        private readonly IDialogService _dialogService;

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

        public NetworkDashboardViewModel(IFileService fileService, IDialogService dialogService)
        {

            ClickCmd = new DelegateCommand<NetworkComponents>(Click);


            _fileService = fileService;
            _dialogService = dialogService;


            _networkComponents = new ObservableCollection<NetworkComponents>
                (_fileService.ProcessReadAsync(Paths.networkComponents)
               .OrderBy(x => x.TotalDayThroughput));
            _dialogService = dialogService;
        }

        private void Click(NetworkComponents networkComponents)
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



        //public ViewAViewModel()
        //{
        //    
        //}
    }
}
