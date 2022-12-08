using CourierManagement.Database.Tables;
using Microsoft.EntityFrameworkCore;

namespace CourierManagement.Database
{
    public class CourierManagmentContext : DbContext
    {
        public CourierManagmentContext(DbContextOptions<CourierManagmentContext> options)
            : base(options)
        {
        }

        public DbSet<Courier> Couriers { get; set; }

    }
}
 