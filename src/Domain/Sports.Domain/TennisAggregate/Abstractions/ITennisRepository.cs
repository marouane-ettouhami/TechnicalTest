using Sports.Domain.TennisAggregate.Entities;
using Sports.Domain.TennisAggregate.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sports.Domain.TennisAggregate.Abstractions
{
    public interface ITennisRepository
    {
        public Task<List<Player>> GetAllPlayersRanked();
        public Task<Player> GetPlayerInfoById(int playerId);
        public Task<Stats> GetStats();
    }
}
