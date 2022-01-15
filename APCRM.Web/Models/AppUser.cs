using APCRM.Web.Utility;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace APCRM.Web.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName;  } }
        public string Photo { get; set; } = APCRMConstants.DefaultPhoto;
    }
}
