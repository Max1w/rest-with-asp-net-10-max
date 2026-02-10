using Microsoft.EntityFrameworkCore;
using RestWithASPNET10.Data.DTO;

namespace RestWithASPNET10.Models.Context
{
    public class MSSQLContext: DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options) 
            : base(options) {}

        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
	}
}
