using Microsoft.Extensions.Logging;
using Moq;
using Sports.Domain.Exceptions;
using Sports.Domain.TennisAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Sports.Domain.Tests.Domain.TennisHandlerTests
{
    public class GetAllPlayersRankedTests : TennisHandlerTestBase
    {
        [Fact]
        public async Task GetAllPlayersRanked_WhenOk_ReturnsPlayers()
        {
            _mockTennisRepository.Setup(x => x.GetAllPlayersRanked())
                .ReturnsAsync(new List<Player>());

            var result = await _tennisHandler.GetAllPlayersRanked().ConfigureAwait(false);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAllPlayersRanked_WhenExceptionThrown_LogErrorAndThrowsException()
        {
            _mockTennisRepository.Setup(x => x.GetAllPlayersRanked())
                .ThrowsAsync(new Exception());

            await Assert.ThrowsAsync<TennisException>(async () => await _tennisHandler.GetAllPlayersRanked().ConfigureAwait(false));

            _mockTennisRepository.Verify(x => x.GetAllPlayersRanked(), Times.Once);
                
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
