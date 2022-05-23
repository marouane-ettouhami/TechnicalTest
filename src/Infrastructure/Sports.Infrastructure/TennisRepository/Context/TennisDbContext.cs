using Microsoft.EntityFrameworkCore;
using Sports.Domain.TennisAggregate.Entities;

namespace Sports.Infrastructure.TennisRepository.Context
{
    public class TennisDbContext : DbContext
    {
        public TennisDbContext(DbContextOptions<TennisDbContext> opt) : base(opt)
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Data> Datas { get; set; }
        public DbSet<LastGames> LastGames { get; set; }
    }
}
