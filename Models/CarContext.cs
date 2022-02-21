using Microsoft.EntityFrameworkCore;

namespace CmdApi.Models
{
    public class CarContext : DbContext
    {
        ///Context constructor for options using.
        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {

        }

        ///DbSet new table base on model/car.cs
        public DbSet<Car> Cars { get; set; }
    }
}
