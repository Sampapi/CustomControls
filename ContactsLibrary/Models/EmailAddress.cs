
namespace Contacts.Models
{
    public class EmailAddress : Entity
    { 
        public string Email { get; set; }

        public string Comment { get; set; }
        public override string ToString() => Email;

        public EmailAddress() {; }
        public EmailAddress( string email, string comment = "") { Email = email; Comment = comment; }
    }
}
