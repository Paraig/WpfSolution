using Interfaces.Models;
using Interfaces.ProcessExcel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfSolution.Helpers;

namespace WpfSolution.ViewModels
{
    public class FileUploadVm : BaseVm
    {
        private string _filePath;
        private IProcessExcel _processExcel;
        private IList<ITransactionData> _failedTransactions;
        private int _countSuccessful;
        BackgroundWorker _worker;

        public FileUploadVm(IProcessExcel processExcel)
        {
            _processExcel = processExcel;
        }

        public string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                if (String.IsNullOrEmpty(value) )
                    return;

                _filePath = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand UploadFileCommand
        {
            get { return new RelayCommand(UploadFileExecute, CanUploadFile); }
        }

        private void UploadFileExecute(object obj)
        {
            if(FailedTransactions != null && FailedTransactions.Any())
                FailedTransactions.Clear();

            _worker = new BackgroundWorker();
            _worker.WorkerReportsProgress = true;
            _worker.DoWork += DoWork;
            _worker.ProgressChanged += ProgressChanged;
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workerCompleted);
            _worker.RunWorkerAsync();
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            _processExcel.ProcessExcelFile(_filePath, UploadProgress);
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            CurrentProgress = e.ProgressPercentage;
        }

        void workerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CountSuccessful = _processExcel.Successful;
            FailedTransactions = _processExcel.FailedTransactions;
        }

        public void UploadProgress(int progress)
        {
            _worker.ReportProgress(progress);
            CurrentProgress = progress;
        }

        private bool CanUploadFile(object obj)
        {
            return !(String.IsNullOrEmpty(_filePath));
        }

        private double _currentProgress;
        public double CurrentProgress
        {
            get { return _currentProgress; }
            private set
            {
                _currentProgress = value;
                NotifyPropertyChanged();
            }
        }

        public IList<ITransactionData> FailedTransactions
        {
            get { return _failedTransactions; }
            set
            {
                if (value == null)
                    return;
                _failedTransactions = value;
                NotifyPropertyChanged();

            }
        }

        public int CountSuccessful
        {
            get { return _countSuccessful; }
            set
            {
                _countSuccessful = value;
                NotifyPropertyChanged();
            }
        }
    }
}
