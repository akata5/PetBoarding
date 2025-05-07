using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PetBnB.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<BookingModel> Bookings { get; set; }
        public DbSet<BookingStatusLogModel> BookingStatusLogModels { get; set; }
        public DbSet<ContactUsSubmissionModel> ContactSubmissionModels { get; set; }
        public DbSet<EmployeeModel> EmployeeModels { get; set; }
        public DbSet<PetModel> PetModels { get; set; }
        public DbSet<PetOwnerModel> PetOwnerModels { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}