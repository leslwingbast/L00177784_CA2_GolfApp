using Microsoft.EntityFrameworkCore;

namespace L00177784_CA2_GolfApp.Data
{
    public class GolfAppDBContext : DbContext
    {
        public DbSet<GolfMember> GolfMembers { get; set; }
        public DbSet<TeeTime> TeeTimes { get; set; }

        public GolfAppDBContext(DbContextOptions<GolfAppDBContext> options)
            : base(options)
        {
        }
    }
}
