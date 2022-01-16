namespace APCRM.Web.Models.ViewModel
{
    public class UserViewModel
    {
        public IEnumerable<AppUser> UsersList { get; set; }
        public AppUser user { get; set; }
    }
}
