using ContactsModule.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace TestProject.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Test Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand LoadPeopleView { get; private set; }


        public IRegionManager RegionManager { get; set; }
        public MainWindowViewModel(IRegionManager regionManager)
        {
            RegionManager = regionManager;
            LoadPeopleView = new DelegateCommand(NavigateToPeopleView);
        }

        #region Navigation
        private void NavigateToPeopleView()
        {
            RegionManager.RequestNavigate("ContentRegion", nameof(PersonDetailView));
        }
        #endregion

    }
}
