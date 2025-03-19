using CarRental.Model;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Data
{
    public class CarDbContext:DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext>options):base(options)
        {
            
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
      
    }
}
