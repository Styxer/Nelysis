using Nelysis.Core.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;

namespace Nelysis.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public DelegateCommand ClosingCmd { get; private set; }

        private string _title = "Nelysis Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {
            ClosingCmd = new DelegateCommand(ClosingExecute);
        }

        private void ClosingExecute()
        {
            //TODO: Delete temp folder?
        }
    }
}
