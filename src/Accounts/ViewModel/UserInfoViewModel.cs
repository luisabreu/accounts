
using System.ComponentModel.DataAnnotations;

namespace Accounts.ViewModel {
    public class UserInfoViewModel {
        [Required]
        public string GivenName { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Department { get; set; }
    }
}