using APCRM.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APCRM.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppSettings> Settings { get; set; } 

        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EnquiryStatus> EnquiryStatus { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Deliverable> Deliverables { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<ProductDocket> ProductDockets { get; set; }
        public DbSet<DeliverableDocket> DeliverableDockets { get; set; }
        public DbSet<CustomerDetails> Customers { get; set; }     
        public DbSet<Event> Events { get; set; }
    }
}
