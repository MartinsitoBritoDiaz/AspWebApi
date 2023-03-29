using Microsoft.EntityFrameworkCore;
using Web_API.Modals;

namespace Web_API.Data.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
    }
}
