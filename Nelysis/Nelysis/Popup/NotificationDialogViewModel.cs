using Nelysis.Core.Models;
using Nelysis.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;


namespace Nelysis.Popup
{
    public class NotificationDialogViewModel : BindableBase, IDialogAware
    {
        private readonly IFileService<NetworkComponent> _fileService;

        #region Commands
        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand =>
            _closeDialogCommand ??
            (_closeDialogCommand = new DelegateCommand<string>(CloseDialog)); 
        #endregion

        #region Props
        private NetworkComponent _networkComponents;
        public NetworkComponent NetworkComponents
        {
            get { return _networkComponents; }
            set { SetProperty(ref _networkComponents, value); }
        }

        private string _title = "Notification";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        #endregion

        #region Events
        public event Action<IDialogResult> RequestClose; 
        #endregion

        #region Ctor
        public NotificationDialogViewModel(IFileService<NetworkComponent> fileService)
        {
            _fileService = fileService;
        }

        #endregion
        protected virtual void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;

           

            if (parameter == "true")
            {
                result = ButtonResult.OK;
            }
            else if (parameter == "false")
            {
                result = ButtonResult.Cancel;
            }

            RaiseRequestClose(new DialogResult(result));
        }

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        public virtual bool CanCloseDialog()
        {
            return true;
        }

        public virtual void OnDialogClosed()
        {

        }

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
            NetworkComponents = parameters.GetValue<NetworkComponent>("message");
        }
    }
}
