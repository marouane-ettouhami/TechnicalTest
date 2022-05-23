using Microsoft.AspNetCore.Mvc;
using Moq;
using Sports.Domain.Exceptions;
using Sports.Domain.TennisAggregate.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Sports.Api.Tests.Unit.TennisControllerTests
{
    public class GetAllPlayersRankedTests : TennisControllerTestBase
    {
        [Fact]
        public async Task GetAllPlayersRanked_WhenOk_ReturnsStatusCode200()
        {
            _mockTennisHandler.Setup(x => x.GetAllPlayersRanked())
                .ReturnsAsync(new List<Player>());

            var result = await _tennisController.GetAllPlayersRanked().ConfigureAwait(false);
            
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetAllPlayersRanked_WhenExceptionThrown_ReturnsInternalServerError()
        {
            int expectedStatusCode = 500;
            _mockTennisHandler.Setup(x => x.GetAllPlayersRanked())
                .ThrowsAsync(new TennisException());

            var players = await _tennisController.GetAllPlayersRanked().ConfigureAwait(false);
            var result = players.Result as ObjectResult;

            Assert.Equal(expectedStatusCode, result.StatusCode);
        }
    }
}
