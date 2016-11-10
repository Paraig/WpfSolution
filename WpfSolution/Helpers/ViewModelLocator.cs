using DAL;
using Interfaces.DAL;
using Ninject;
using Ninject.Modules;
using WpfSolution.ViewModels;

namespace WpfSolution.Helpers
{
    public class ViewModelLocator
    {
        public class WpfNinjectBootstrapper : NinjectBootstrapper
        {
            #region Methods

            protected override void ConfigureContainer()
            {
                base.ConfigureContainer();
                //The aggregator needs to be a singleton otherwise each module will get a different copy
                this.Kernel.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
            }

            protected override DependencyObject CreateShell()
            {
                return new Shell();
            }

            protected override void InitializeModules()
            {
                base.InitializeModules();
                //Load all NinjectModule type dlls in the current directory into the Kernel
                // and call  each module's Load method
                //Need to add references in this project to the modules that are situated in other 
                //projects for this to work.
                Kernel.Load("*.dll");
            }

            protected override void InitializeShell()
            {
                base.InitializeShell();
                Application.Current.MainWindow = (Shell)this.Shell;
                Application.Current.MainWindow.Show();
            }

            #endregion
        }


        //public MainWindowVM ShellViewModel
        //{
        //    get
        //    {
        //        return Kernel.Get<MainWindowVM>();
        //    }
        //}

        //private static readonly IKernel Kernel;
        //static ViewModelLocator()
        //{
        //    if (Kernel == null)
        //    {
        //        Kernel = new StandardKernel(new NumberGameModule());

        //    }
        //}

        //public class NumberGameModule : NinjectModule
        //{
        //    public override void Load()
        //    {
        //        Kernel.Bind<IDal>().To<Dal>();
        //    }
        //}
    }
}
