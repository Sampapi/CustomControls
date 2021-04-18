using Contacts.Models;
using Contacts.Wrappers;

namespace Contacts.Wrappers
{
    public class PhoneNumberWrapper : ModelWrapper<PhoneNumber>
    {
        public PhoneNumberWrapper(PhoneNumber phoneNumber) : base(phoneNumber)
        {
        }

        public int Id
        {
            get => GetValue<int>();
            set { SetValue(value); }
        }
        public int IdOriginalValue => GetOriginalValue<int>(nameof(Id));
        public bool IdIsChanged => GetIsChanged(nameof(Id));

        public string Number
        {
            get => GetValue<string>();
            set { SetValue(value); }
        }
        public string NumberOriginalValue => GetOriginalValue<string>(nameof(Number));
        public bool NumberIsChanged => GetIsChanged(nameof(Number));
    }
}
