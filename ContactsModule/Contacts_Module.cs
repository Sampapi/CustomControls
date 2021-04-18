using ContactsModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ContactsModule
{
    public class Contacts_Module : IModule
    {
        private readonly IRegionManager _regionManager;

        public Contacts_Module(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<PersonDetailView>();
        }
    }
}