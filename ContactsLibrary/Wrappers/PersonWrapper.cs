using Contacts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Contacts.Wrappers
{
    public class PersonWrapper : ModelWrapper<Person>
    {
        public PersonWrapper(Person person, CollectionInitialization initializeGroups = CollectionInitialization.Initialize)
            : base(person, initializeGroups)
        {
        }

        protected override void InitializeComplexProperties(Person person)
        {
            if (person.HomeAddress is null) { person.HomeAddress = new Address(); }

            HomeAddress = new AddressWrapper(person.HomeAddress);
            RegisterComplex(HomeAddress);

            if (person.HomePhoneNumber is null) { person.HomePhoneNumber = new PhoneNumber(); }
            HomePhoneNumber = new PhoneNumberWrapper(person.HomePhoneNumber);
            RegisterComplex(HomePhoneNumber);

            if (person.CellPhoneNumber is null) { person.CellPhoneNumber = new PhoneNumber(); }
            CellPhoneNumber = new PhoneNumberWrapper(person.CellPhoneNumber);
            RegisterComplex(CellPhoneNumber);
        }

        protected override void InitializeCollectionProperties(Person person)
        {
            if (person.Emails is null) { person.Emails = new(); }

            Emails = new ChangeTrackingCollection<EmailWrapper>(person.Emails.Select(emailAddress => new EmailWrapper(emailAddress)));
            RegisterCollection(Emails, person.Emails);


            if (person.Groups is null) { person.Groups = new(); }

            Groups = new ChangeTrackingCollection<GroupWrapper>
                (person.Groups.Select(group => new GroupWrapper(group, CollectionInitialization.DoNotInitialize)));
            RegisterCollection(Groups, person.Groups);
        }

        public int Id
        {
            get => GetValue<int>();
            set { SetValue(value); }
        }
        public int IdOriginalValue => GetOriginalValue<int>(nameof(Id));
        public bool IdIsChanged => GetIsChanged(nameof(Id));

        [Required(ErrorMessage = "First name is required")]
        public string FirstName
        {
            get => GetValue<string>();
            set { SetValue(value); }
        }
        public string FirstNameOriginalValue => GetOriginalValue<string>(nameof(FirstName));
        public bool FirstNameIsChanged => GetIsChanged(nameof(FirstName));

        public string LastName
        {
            get => GetValue<string>();
            set { SetValue(value); }
        }
        public string LastNameOriginalValue => GetOriginalValue<string>(nameof(LastName));
        public bool LastNameIsChanged => GetIsChanged(nameof(LastName));

        public string Display => Model.Display;

        public DateTime? Birthday
        {
            get => GetValue<DateTime?>();
            set { SetValue(value); }
        }
        public DateTime? BirthdayOriginalValue => GetOriginalValue<DateTime?>(nameof(Birthday));
        public bool BirthdayIsChanged => GetIsChanged(nameof(Birthday));

        public PhoneNumberWrapper HomePhoneNumber { get; set; }
        public PhoneNumberWrapper CellPhoneNumber { get; private set; }

        public AddressWrapper HomeAddress { get; set; }

        public ChangeTrackingCollection<EmailWrapper> Emails { get; private set; }
        public ChangeTrackingCollection<GroupWrapper> Groups { get; private set; }

        // All the validation logic for the class can be inserted into this method if desired.
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Emails is not null && Emails.Count == 0)    // i.e. Emails can be null when wrapping people who are members of groups.
            {
                yield return new ValidationResult("A person must have an email address", new[] { nameof(Emails) });
            }
        }
    }
}
