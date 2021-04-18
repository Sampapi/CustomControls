using ContactsModule;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.Windows;
using TestProject.Views;

namespace TestProject
{
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

       
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<Contacts_Module>();
        }

    }
}
