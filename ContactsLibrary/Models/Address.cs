
namespace Contacts.Models
{
    public class Address : Entity
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }

        public string ProvinceOrState { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public string Display => $"{StreetNumber} {Street}, {City}, {ProvinceOrState}, {Country}, {PostalCode}";
        public override string ToString() => Display;
    }
}