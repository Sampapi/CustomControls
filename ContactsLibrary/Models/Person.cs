using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Contacts.Models
{
    public class Person : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Display => $"{FirstName} {LastName}";
        public override string ToString() => Display;       
        public DateTime? Birthday { get; set; }

        public Address HomeAddress { get; set; }

        public PhoneNumber HomePhoneNumber { get; set; }
        public PhoneNumber CellPhoneNumber { get; set; }

        public List<EmailAddress> Emails { get; set; }
        public List<Group> Groups { get; set; }
    }
}
