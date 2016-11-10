using Interfaces.DAL;
using Interfaces.Enums;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfSolution.Helpers;

namespace WpfSolution.ViewModels
{
    public class MainWindowVM : BaseVm
    {
        private BaseVm _selectedContent;
        //private FileUploadVm _selectedContentF;

        private IDal _dal;

        public MainWindowVM(IDal dal)
        {
            _dal = dal;
            //SelectedContent = new TransactionsListVm();
        }

        //[Inject]
        //public IDal dal { get; set; }

        public ICommand MenuSelectCommand
        {
            get { return new RelayCommand(MenuSelectExecute, CanMenuSelect); }
        }

        private void MenuSelectExecute(object obj)
        {
            var selector = (MenuItems) int.Parse(obj.ToString());

            switch(selector)
            {
                case MenuItems.TransactionList:
                    var data = _dal.LoadTransactionData();
                    SelectedContent = new TransactionsListVm { Transactions = data};
                    return;                
            }
            SelectedContent = ((App)Application.Current).Container.Get<FileUploadVm>();//  AppDomain.. .Co new FileUploadVm();

        }

        private bool CanMenuSelect(object obj)
        {
            return true;
        }

        public BaseVm SelectedContent
        {
            get
            {
                return _selectedContent;
            }
            set
            {
                if (value != null)
                    _selectedContent = value;
                NotifyPropertyChanged();
            }
        }

    }
}
