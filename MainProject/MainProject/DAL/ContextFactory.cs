using Microsoft.EntityFrameworkCore;
using MainProject.DAL;

namespace MainProject.Services
{
    public class ContextFactory : IDbContextFactory<Context>
    {
        private readonly DbContextOptions<Context> _options;

        public ContextFactory(DbContextOptions<Context> options)
        {
            _options = options;
        }

        public Context CreateDbContext()
        {
            return new Context(_options);
        }
    }
}
