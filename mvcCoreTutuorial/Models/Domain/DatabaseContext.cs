using Microsoft.EntityFrameworkCore;

namespace mvcCoreTutuorial.Models.Domain
{
	public class DatabaseContext : DbContext
	{
        public DatabaseContext(DbContextOptions<DatabaseContext> opts) : base(opts)
        
        {

                
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Address> Address { get; set; }
    } 
     
}
