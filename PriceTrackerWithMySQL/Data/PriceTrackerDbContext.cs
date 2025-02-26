using Microsoft.EntityFrameworkCore;
using PriceTrackerWithMySQL.Models;

namespace PriceTrackerWithMySQL.Data
{
    public class PriceTrackerDbContext:DbContext
    {
        public DbSet<PriceModel> TblPrice { get; set; }

        public PriceTrackerDbContext(DbContextOptions<PriceTrackerDbContext>options):base(options)
        {
            
        }
    }
}
