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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Worksheet>()
                   .HasOne(c => c.WorkStatus)
                   .WithMany()
                   .OnDelete(DeleteBehavior.ClientNoAction);
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{     

        //    builder.Entity<Worksheet>()
        //           .HasOne(c => c.WorkStatus)
        //           .WithMany()
        //           .OnDelete(DeleteBehavior.ClientNoAction);
        //}

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
        public DbSet<WorkPhase> WorkPhases { get; set; }
        public DbSet<WorkStatus> WorkStatus { get; set; }
        public DbSet<Enquiry> enquiry { get; set; }
        public DbSet<Worksheet> Worksheet { get; set; }
        public DbSet<WorksheetProduct> WorksheetProduct { get; set; }
        public DbSet<WorksheetPaymentLog> WorksheetPaymentLog { get; set; }
        public DbSet<WorksheetPaymentStatus> WorksheetPaymentStatus { get; set; }
        public DbSet<WorksheetDeliverable>  WorksheetDeliverable { get; set; }
    }
}
