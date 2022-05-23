using Microsoft.Extensions.Logging;
using Sports.Domain.Exceptions;
using Sports.Domain.TennisAggregate.Abstractions;
using Sports.Domain.TennisAggregate.Entities;
using Sports.Domain.TennisAggregate.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sports.Domain.TennisAggregate.Handlers
{
    public class TennisHandler : ITennisHandler
    {
        private readonly ITennisRepository _tennisRepository;
        private readonly ILogger<TennisHandler> _logger;
        public TennisHandler(ITennisRepository tennisRepository, ILogger<TennisHandler> logger)
        {
            _tennisRepository = tennisRepository ?? throw new ArgumentNullException(nameof(tennisRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<List<Player>> GetAllPlayersRanked()
        {
            // Business logic here ... Maybe do some calculations, verfications ...

            try
            {
                return await _tennisRepository.GetAllPlayersRanked();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Cannot get players ranked ");
                throw new TennisException();
            }
        }

        public async Task<Player> GetPlayerInfoById(int playerId)
        {
            // Business logic here ... Maybe do some calculations, verfications ...

            try
            {
                return await _tennisRepository.GetPlayerInfoById(playerId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Cannot get players {playerId} info ");
                throw new TennisException();
            }
        }

        public async Task<Stats> GetStats()
        {
            // Business logic here ... Maybe do some calculations, verfications ...

            try
            {
                return await _tennisRepository.GetStats();
            }
            catch (Exception ex)
            {
                _logger.LogError("Cannot get stats ", ex);
                throw new TennisException();
            }
        }
    }
}
