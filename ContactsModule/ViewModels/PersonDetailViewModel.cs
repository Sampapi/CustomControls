using Contacts.Models;
using Contacts.Wrappers;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using ViewModels;

namespace ContactsModule.ViewModels
{
    public class PersonDetailViewModel : ViewModelBase
    {
        #region Services
        private readonly IEventAggregator _eventAggregator;
        #endregion

        #region Commands
        public DelegateCommand CloseCommand { get; private set; }

        public DelegateCommand SavePersonCommand { get; private set; }
        public DelegateCommand ResetPersonCommand { get; private set; }
        public DelegateCommand DeletePersonCommand { get; private set; }

        public DelegateCommand AddGroupCommand { get; private set; }
        public DelegateCommand RemoveGroupCommand { get; private set; }

        public DelegateCommand AddEmailCommand { get; private set; }
        public DelegateCommand RemoveEmailCommand { get; private set; }
        #endregion

        #region Constructor
        public PersonDetailViewModel(IEventAggregator eventAggregator) : base()
        {
            _eventAggregator = eventAggregator;
        }
        #endregion

        #region SelectedPerson
        private bool IsNewlyCreatedPerson() => SelectedPerson.Id <= 0;

        private PersonWrapper _selectedPerson;
        public PersonWrapper SelectedPerson
        {
            get => _selectedPerson;
            set => SetProperty(ref _selectedPerson, value);
        }

        public void LoadSelectedPerson(int personId)
        {
            var selectedPerson = new Person
            {
                Id = 11,
                FirstName = "Janis",
                LastName = "Joplan",
                Birthday = DateTime.Today,
                CellPhoneNumber = new() { Number = "450-881-9868" },
                Emails = new(),
                Groups = new(),
                HomeAddress = new() { StreetNumber = "1555", Street = "Cormier st", City = "Drummondville", Country = "Canada", ProvinceOrState = "Quebec" }
            };

            SelectedPerson = new PersonWrapper(selectedPerson);
        }

        private bool OnResetCanExecute() => SelectedPerson is not null && SelectedPerson.IsChanged;
        private void OnResetExecute() => SelectedPerson.RejectChanges();

        #endregion


        #region Emails
        private EmailWrapper _selectedEmail;
        public EmailWrapper SelectedEmail
        {
            get { return _selectedEmail; }
            set { SetProperty(ref _selectedEmail, value); }
        }

        private bool OnRemoveEmailCanExecute() => SelectedEmail is not null;
        
        private void OnAddEmailExecute() => SelectedPerson.Emails.Add(new EmailWrapper(new EmailAddress()));

        #endregion


        #region Navigation
        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            int personId = navigationContext.Parameters.GetValue<int>("Id");

            if (SelectedPerson is null) { return false; }
            if (SelectedPerson.Id == personId) { return true; }
            return false;
        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            base.OnNavigatedFrom(navigationContext);
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //if (!navigationContext.Parameters.ContainsKey("Id")) { return; }

            if (SelectedPerson is not null) { return; }         // Don't reload the person if he is already is memory.

            int personId = navigationContext.Parameters.GetValue<int>("Id");
            LoadSelectedPerson(personId);
        }


        #endregion
    }
}
