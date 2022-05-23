using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sports.Api.TennisFeature.Mappers;
using Sports.Domain.TennisAggregate.Abstractions;
using Sports.Domain.TennisAggregate.Entities;
using Sports.Domain.TennisAggregate.Models;
using Sports.Domain.TennisAggregate.ReadDtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sports.Api.TennisFeature.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TennisController : ControllerBase
    {
        private readonly ITennisHandler _tennisHandler;
        // Not used here, but may be used later ...
        private readonly ILogger<TennisController> _logger;
        public TennisController(ITennisHandler tennisHandler, ILogger<TennisController> logger)
        {
            _tennisHandler = tennisHandler ?? throw new ArgumentNullException(nameof(tennisHandler));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("players")]
        public async Task<ActionResult<List<PlayerReadDto>>> GetAllPlayersRanked()
        {
            try
            {
                var players = await _tennisHandler.GetAllPlayersRanked().ConfigureAwait(false);
                return Ok(Mapper.ToPLayerDtos(players));
            }
            catch (Exception)
            {
                // Not the best practice, but since we don't have enough specifications, we'll be returning a 500 error
                return StatusCode(StatusCodes.Status500InternalServerError, "unable to get players info");
            }
        }

        [HttpGet("players/{playerId:int}", Name = "GetPlayerById")]
        public async Task<ActionResult<Player>> GetPlayerInfoById(int playerId)
        {
            try
            {
                var player = await _tennisHandler.GetPlayerInfoById(playerId).ConfigureAwait(false);
                if (player is null)
                {
                    return NotFound();
                }

                return Ok(Mapper.ToPlayerDto(player));
            }
            catch (Exception)
            {
                // Not the best practice, but since we don't have enough specifications, we'll be returning a 500 error
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("players/stats")]
        public async Task<ActionResult<Stats>> GetStats()
        {
            try
            {
                return Ok(await _tennisHandler.GetStats());
            }
            catch (Exception)
            {
                // Not the best practice, but since we don't have enough specifications, we'll be returning a 500 error
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to get players stats");
            }
        }

    }
}
