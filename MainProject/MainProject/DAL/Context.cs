using Microsoft.EntityFrameworkCore;
using MainProject.Models;

namespace MainProject.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Prioridades> Prioridades { get; set; }
    }
}
