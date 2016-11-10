using Interfaces.DAL;
using Interfaces.Models;
using Interfaces.ProcessExcel;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessExcel
{
    public class ProcessExcel : IProcessExcel
    {
        IDal _dal;
        int _count;

        public ProcessExcel(IDal dal)
        {
            _dal = dal;
            FailedTransactions = new List<ITransactionData>();
        }

        public void ProcessExcelFile(string fileName, Action<int>progress)
        {
            progress(0);

            var book = new LinqToExcel.ExcelQueryFactory(fileName);
            book.DatabaseEngine = LinqToExcel.Domain.DatabaseEngine.Ace;

            int rowNumber = 1;
            _count = 0;

            var tranactionData =
                from row in book.Worksheet("Sheet1")
                let item = new TransactionData
                {
                    Code = row["Account"].Cast<string>(),
                    Description = row["Description"].Cast<string>(),
                    Currency = row["Currency Code"].Cast<string>(),
                    Amount = row["Amount"].Cast<decimal>(),
                }
                select item;

            var rowsToProcess = tranactionData.Count();

            foreach (var datum in tranactionData)
            {
                datum.RowNumber = rowNumber++;
                if (datum.IsValid)
                {
                    _dal.AddTransaction(datum);
                    _count++;
                }
                else
                {
                    FailedTransactions.Add(datum);
                }
                progress((int)((double)datum.RowNumber / rowsToProcess *100));
            }


        }

        public IList<ITransactionData> FailedTransactions
        {
            get; private set;
        }

        public int Successful
        {
            get
            {
                return _count;
            }
        }
    }
}
