using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace APCRM.Web.Models.ViewModel
{
    public class UserViewModel
    {
        public IEnumerable<AppUser> UsersList { get; set; }        
        public AppUser user { get; set; }

        public NewUser newuser { get; set; }
    }

    public class NewUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public IEnumerable<SelectListItem> RoleList { get; set; }

        public string RoleSelected { get; set; }
    }
}
