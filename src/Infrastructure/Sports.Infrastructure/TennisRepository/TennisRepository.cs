using Microsoft.EntityFrameworkCore;
using Sports.Domain.Exceptions;
using Sports.Domain.TennisAggregate.Abstractions;
using Sports.Domain.TennisAggregate.Entities;
using Sports.Domain.TennisAggregate.Models;
using Sports.Infrastructure.TennisRepository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sports.Infrastructure.TennisRepository
{
    public class TennisRepository : ITennisRepository
    {
        private readonly TennisDbContext _dbContext;
        public TennisRepository(TennisDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<Player>> GetAllPlayersRanked()
        {
            try
            {
               return  await _dbContext.Players
                    .Include(c => c.Country)
                    .Include(p => p.Data)
                    .ThenInclude(l => l.Last)
                    .OrderBy(p => p.Data.Rank)
                    .ToListAsync();                
            }
            catch (Exception ex)
            {
                throw new DbException($"Error while retrieving players from database: ", ex);
            }
        }

        public async Task<Player> GetPlayerInfoById(int playerId)
        {
            try
            {
                return await _dbContext.Players.Where(p => p.Id == playerId)
                    .Include(c => c.Country)
                    .Include(p => p.Data)
                    .ThenInclude(l => l.Last)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new DbException($"Error while retrieving player {playerId} from database: ", ex);
            }
        }

        public async Task<Stats> GetStats()
        {
            try
            {
                var countryWithMostWins = _dbContext.Players.Join(
                        _dbContext.LastGames,
                        player => player.Data.DataId,
                        lastGame => lastGame.DataId,
                        (player, lastGame) => new { player.CountryCode, lastGame.Result })
                            .GroupBy(c => c.CountryCode).
                              Select(g => new
                              {
                                  g.Key,
                                  Ratio = ((decimal)g.Sum(s => s.Result)) / g.Count()
                              }).OrderByDescending(x => x.Ratio).First().Key;

                return new Stats
                {
                    BMI = await _dbContext.Players.Select(p => p.Data.Weight).AverageAsync(),
                    MedianHeight = await _dbContext.Players.Select(p => p.Data.Height).AverageAsync(),
                    CountryWithMostWins = await _dbContext.Countries.FindAsync(countryWithMostWins)
                };
            }
            catch (Exception ex)
            {
                throw new DbException($"Error while retrieving players stats from database: ", ex);
            }
        }
    }
}
