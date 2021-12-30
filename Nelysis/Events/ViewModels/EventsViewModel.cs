using Nelysis.Core;
using Nelysis.Core.Models;
using Nelysis.Services.Interfaces;

using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.ViewModels
{
    public class EventsViewModel : BindableBase
    {
        #region Services
        private readonly IFileService<Event> _fileService;
        #endregion

        #region Cmds
        //public DelegateCommand<NetworkComponents> ClickCmd { get; private set; }
        public DelegateCommand<string> OrderByCmd { get; private set; }
        #endregion

        #region Properties
        private ObservableCollection<Event> _events;
        public ObservableCollection<Event> Events
        {
            get { return _events; }
            set { SetProperty(ref _events, value); }
        }

        private Event _selectedItem;
        public Event SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }

        #endregion

        #region Ctor
        public EventsViewModel(IFileService<Event> fileService)
        {
            _fileService = fileService;

           // ClickCmd = new DelegateCommand<NetworkComponents>(ClickExecute);
            OrderByCmd = new DelegateCommand<string>(OrderByExecute);

            _events = new ObservableCollection<Event>
            (_fileService.ProcessReadAsync(Paths.EventsPath)
           .OrderBy(x => x.TimeAction));


        }

        private void OrderByExecute(string headerName)
        {

            //TOOD: NOT HARD CODED NAMES

            if (headerName == "IP Address")
            {
                _events = new ObservableCollection<Event>(_events.OrderBy(x => x.IPAddress));
            }

        }

        #endregion
    }
}
