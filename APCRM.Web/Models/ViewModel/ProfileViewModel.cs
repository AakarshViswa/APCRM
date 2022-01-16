using System.ComponentModel.DataAnnotations;

namespace APCRM.Web.Models.ViewModel
{
    public class ProfileViewModel
    {
        //[Required]
        //public string FirstName { get; set; }

        //[Required]
        //public string LastName { get; set; }

        //[Required]
        //[EmailAddress]
        //public string Email { get; set; }

        //[Required]
        //[Phone]
        //public string PhoneNumber { get; set; }

        //public string Photo { get; set; }

        public AppUser User { get; set; }   

        public string RoleName { get; set; }

        public static implicit operator Task<object>(ProfileViewModel v)
        {
            throw new NotImplementedException();
        }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at lest {2} characters long", MinimumLength = 6)]
        public string CurrentPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at lest {2} characters long", MinimumLength = 6)]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The Password and confirm Password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
