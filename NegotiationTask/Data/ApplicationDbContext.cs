using Microsoft.EntityFrameworkCore;
using NegotiationTask.Models;

namespace NegotiationTask.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
    }
}
