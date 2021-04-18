using Contacts.Models;
using System.Linq;

namespace Contacts.Wrappers
{
    public class GroupWrapper : ModelWrapper<Group>
    {
        public GroupWrapper(Group group, CollectionInitialization initializeCollection = CollectionInitialization.Initialize)
            : base(group, initializeCollection)
        {
        }

        protected override void InitializeCollectionProperties(Group group)
        {

            if (group.People is null) { group.People = new(); }
            People = new ChangeTrackingCollection<PersonWrapper>
                (group.People.Select(person => new PersonWrapper(person, CollectionInitialization.DoNotInitialize)));
            RegisterCollection(People, group.People);
        }

        public int Id
        {
            get => GetValue<int>();
            set { SetValue(value); }
        }
        public int IdOriginalValue => GetOriginalValue<int>(nameof(Id));
        public bool IdIsChanged => GetIsChanged(nameof(Id));

        public string Name
        {
            get => GetValue<string>();
            set { SetValue(value); }
        }
        public string NameOriginalValue => GetOriginalValue<string>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

        public string Description
        {
            get => GetValue<string>();
            set { SetValue(value); }
        }
        public string DescriptionOriginalValue => GetOriginalValue<string>(nameof(Description));
        public bool DescriptionIsChanged => GetIsChanged(nameof(Description));

        public ChangeTrackingCollection<PersonWrapper> People { get; private set; }
    }
}

