using Interfaces.Models;
using System;
using System.Collections.Generic;

namespace Interfaces.ProcessExcel
{
    public interface IProcessExcel
    {
        void ProcessExcelFile(string fileName, Action<int> progress);

        int Successful { get; }

        IList<ITransactionData> FailedTransactions { get; }
    }
}
