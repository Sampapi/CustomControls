using Contacts.Models;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Wrappers
{
    public class AddressWrapper : ModelWrapper<Address>
    {
        public AddressWrapper(Address address) : base(address)
        {
        }

        public int Id
        {
            get => GetValue<int>(); 
            set { SetValue(value); }
        }
        public int IdOriginalValue => GetOriginalValue<int>(nameof(Id));
        public bool IdIsChanged => GetIsChanged(nameof(Id));

        [Required(ErrorMessage ="City is required")]
        public string City
        {
            get => GetValue<string>(); 
            set { SetValue(value); }
        }
        public string CityOriginalValue => GetOriginalValue<string>(nameof(City));
        public bool CityIsChanged => GetIsChanged(nameof(City));

        public string Street
        {
            get => GetValue<string>();
            set { SetValue(value); }
        }
        public string StreetOriginalValue => GetOriginalValue<string>(nameof(Street));
        public bool StreetIsChanged => GetIsChanged(nameof(Street));

        public string StreetNumber
        {
            get => GetValue<string>();
            set { SetValue(value); }
        }
        public string StreetNumberOriginalValue => GetOriginalValue<string>(nameof(StreetNumber));
        public bool StreetNumberIsChanged => GetIsChanged(nameof(StreetNumber));

        public string ProvinceOrState
        {
            get => GetValue<string>();
            set { SetValue(value); }
        }
        public string ProvinceOrStateOriginalValue => GetOriginalValue<string>(nameof(ProvinceOrState));
        public bool ProvinceOrStateIsChanged => GetIsChanged(nameof(ProvinceOrState));

        public string Country
        {
            get => GetValue<string>();
            set { SetValue(value); }
        }
        public string CountryOriginalValue => GetOriginalValue<string>(nameof(Country));
        public bool CountryIsChanged => GetIsChanged(nameof(Country));


        public string PostalCode
        {
            get => GetValue<string>();
            set { SetValue(value); }
        }
        public string PostalCodeOriginalValue => GetOriginalValue<string>(nameof(PostalCode));
        public bool PostalCodeIsChanged => GetIsChanged(nameof(PostalCode));
    }
}
