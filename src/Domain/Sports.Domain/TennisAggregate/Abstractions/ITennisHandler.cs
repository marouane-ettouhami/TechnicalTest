using Sports.Domain.TennisAggregate.Entities;
using Sports.Domain.TennisAggregate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Domain.TennisAggregate.Abstractions
{
    public interface ITennisHandler
    {
        public Task<List<Player>> GetAllPlayersRanked();
        public Task<Player> GetPlayerInfoById(int playerId);
        public Task<Stats> GetStats();
    }
}
