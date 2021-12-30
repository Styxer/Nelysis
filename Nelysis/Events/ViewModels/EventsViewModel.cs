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

namespace Events.ViewModels
{
    public class EventsViewModel : BindableBase , INavigationAware
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

            _events.CollectionChanged += _events_CollectionChanged;

            Collections.events = _events;

           


        }

        private void _events_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Collections.events = _events;
        }

        private void OrderByExecute(string headerName)
        {

            //TOOD: NOT HARD CODED NAMES

            if (headerName == "IP Address")
            {
                _events = new ObservableCollection<Event>(_events.OrderBy(x => x.IPAddress));
            }

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {          
            for (int i = 0; i < Collections.networkComponents.Count(); i++)
            {
                _events[i].IsComponentTypeExternal = Collections.networkComponents[i].ComponentType == Nelysis.Core.Enums.ComponentsTypes.None;
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
           
        }

        #endregion
    }
}
