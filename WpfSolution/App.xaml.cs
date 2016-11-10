using DAL;
using Interfaces.DAL;
using Interfaces.ProcessExcel;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfSolution.ViewModels;

namespace WpfSolution
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel _container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //var bootstrapper = new WpfNinjectBootstrapper();
            //bootstrapper.Run(true);

            ConfigureContainer();
            //ComposeObjects();
            var window = new MainWindow { DataContext = _container.Get<MainWindowVM>()};
            window.Show();
            //Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            this._container = new StandardKernel();
            //container.Bind<IDal>().To<Dal>().InTransientScope();
            _container.Bind<MainWindowVM>().ToSelf();
            _container.Bind<FileUploadVm>().ToSelf();
            _container.Bind<IDal>().To<Dal>();
            _container.Bind<IProcessExcel>().To<ProcessExcel.ProcessExcel>();
        }

        private void ComposeObjects()
        {
            Current.MainWindow = this._container.Get<MainWindow>();
            Current.MainWindow.Title = "DI with Ninject";
        }

        public IKernel Container { get { return _container; } }
    }
}
