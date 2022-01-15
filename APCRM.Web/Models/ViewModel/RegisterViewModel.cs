using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace APCRM.Web.Models.ViewModel
{
    public class RegisterViewModel
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
        [StringLength(100,ErrorMessage ="The {0} must be at lest {2} characters long",MinimumLength = 6)]
        public string Password { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="The Password and confirm Password do not match")]
        public string ConfirmPassword { get; set; }

        public IEnumerable<SelectListItem> RoleList { get; set; }

        public string RoleSelected { get; set; }
    }
}
