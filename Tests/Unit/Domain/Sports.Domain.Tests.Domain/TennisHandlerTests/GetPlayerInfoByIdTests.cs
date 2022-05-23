using Microsoft.Extensions.Logging;
using Moq;
using Sports.Domain.Exceptions;
using Sports.Domain.TennisAggregate.Entities;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Sports.Domain.Tests.Domain.TennisHandlerTests
{
    public class GetPlayerInfoByIdTests : TennisHandlerTestBase
    {
        [Fact]
        public async Task GetPlayerInfoById_WhenOk_ReturnsPlayer()
        {
            _mockTennisRepository.Setup(x => x.GetPlayerInfoById(It.IsAny<int>()))
                .ReturnsAsync(new Player());

            var player = await _tennisHandler.GetPlayerInfoById(It.IsAny<int>()).ConfigureAwait(false);

            Assert.NotNull(player);
        }

        [Fact]
        public async Task GetPlayerInfoById_WhenExceptionThrown_LogErrorAndThrowsException()
        {
            _mockTennisRepository.Setup(x => x.GetPlayerInfoById(It.IsAny<int>()))
                .ThrowsAsync(new Exception());

            await Assert.ThrowsAsync<TennisException>(async () => await _tennisHandler.GetPlayerInfoById(It.IsAny<int>())).ConfigureAwait(false);

            _mockTennisRepository.Verify(x => x.GetPlayerInfoById(It.IsAny<int>()), Times.Once);

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
