using Microsoft.EntityFrameworkCore;

namespace PR.Data
{
    public class PgDbContext : DbContext
    {
        public PgDbContext(DbContextOptions<PgDbContext> options) 
        : base(options)
        { }



    }
}
