using Interfaces.DAL;
using Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSolution.ViewModels
{
    public class TransactionsListVm : BaseVm
    {
        private IEnumerable<ITransactionData> _transactions;

        public TransactionsListVm()
        {
        }

        public IEnumerable<ITransactionData> Transactions
        {
            get
            {
                return _transactions;
            }
            set
            {
                if (value == null)
                    return;
                _transactions = value;
                NotifyPropertyChanged();
            }
        }
    }
}
