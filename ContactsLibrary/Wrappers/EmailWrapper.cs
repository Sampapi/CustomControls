using Contacts.Models;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Wrappers

{
    public class EmailWrapper : ModelWrapper<EmailAddress>
    {
        public EmailWrapper(EmailAddress emailAddress) : base(emailAddress)
        {
        }

        public int Id
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        public int IdOriginalValue => GetOriginalValue<int>(nameof(Id));

        public bool IdIsChanged => GetIsChanged(nameof(Id));

        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage ="Email is not a valid email address")]
        public string Email
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string EmailOriginalValue => GetOriginalValue<string>(nameof(Email));

        public bool EmailIsChanged => GetIsChanged(nameof(Email));

        public string Comment
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string CommentOriginalValue => GetOriginalValue<string>(nameof(Comment));

        public bool CommentIsChanged => GetIsChanged(nameof(Comment));
    }
}
