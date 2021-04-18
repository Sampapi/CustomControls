
using System.Collections.Generic;

namespace Contacts.Models
{
    public class Group : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Person> People { get; set; }

        public Group()
        {
        }
        public Group(string name)
        {
            Name = name;
        }
    }
}
