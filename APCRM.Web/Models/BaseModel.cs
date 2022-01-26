namespace APCRM.Web.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            CreatedAt = DateTime.Now;      
            UpdatedAt = DateTime.Now;
        }

        public DateTime CreatedAt { get; set; }
        public AppUser CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public AppUser UpdatedBy { get; set; }
    }
}
