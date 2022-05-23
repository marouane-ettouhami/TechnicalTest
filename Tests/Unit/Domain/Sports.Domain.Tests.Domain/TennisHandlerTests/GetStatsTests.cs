using Microsoft.Extensions.Logging;
using Moq;
using Sports.Domain.Exceptions;
using Sports.Domain.TennisAggregate.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Sports.Domain.Tests.Domain.TennisHandlerTests
{
    public class GetStatsTests : TennisHandlerTestBase
    {
        [Fact]
        public async Task GetStats_WhenOk_ReturnsStats()
        {
            _mockTennisRepository.Setup(x => x.GetStats())
                .ReturnsAsync(new Stats());

            var stats = await _tennisHandler.GetStats().ConfigureAwait(false);

            Assert.NotNull(stats);
        }

        [Fact]
        public async Task GetStats_WhenExceptionThrown_LogErrorAndThrowsException()
        {
            _mockTennisRepository.Setup(x => x.GetStats())
                .ThrowsAsync(new Exception());

            await Assert.ThrowsAsync<TennisException>(async () => await _tennisHandler.GetStats().ConfigureAwait(false));

            _mockTennisRepository.Verify(x => x.GetStats(), Times.Once);

            _mockLogger.Verify(
                x => x.Log(
               It.Is<LogLevel>(l => l == LogLevel.Error),
               It.IsAny<EventId>(),
               It.Is<It.IsAnyType>((v, t) => true),
               It.IsAny<Exception>(),
               It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), Times.Once);
        }
    }
}
