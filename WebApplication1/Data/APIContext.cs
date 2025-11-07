using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class APIContext:DbContext
    {
        public DbSet<User> Users => Set<User>();
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {
        }
    }
}
