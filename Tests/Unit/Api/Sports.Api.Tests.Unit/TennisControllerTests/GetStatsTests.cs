using Microsoft.AspNetCore.Mvc;
using Moq;
using Sports.Domain.Exceptions;
using Sports.Domain.TennisAggregate.Models;
using System.Threading.Tasks;
using Xunit;

namespace Sports.Api.Tests.Unit.TennisControllerTests
{
    public class GetStatsTests : TennisControllerTestBase
    {
        [Fact]
        public async Task GetStats_WhenOk_ReturnsStatusCode200()
        {
            _mockTennisHandler.Setup(x => x.GetStats())
                .ReturnsAsync(new Stats());
            var result = await _tennisController.GetStats().ConfigureAwait(false);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetStats_WhenExceptionThrown_ReturnsInternalServerError()
        {
            int expectedStatusCode = 500;
            _mockTennisHandler.Setup(x => x.GetAllPlayersRanked())
                .ThrowsAsync(new TennisException());

            var stats = await _tennisController.GetAllPlayersRanked().ConfigureAwait(false);
            var result = stats.Result as ObjectResult;

            Assert.Equal(expectedStatusCode, result.StatusCode);
        }
    }
}
