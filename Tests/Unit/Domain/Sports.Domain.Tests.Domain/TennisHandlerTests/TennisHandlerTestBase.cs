using Microsoft.Extensions.Logging;
using Moq;
using Sports.Domain.TennisAggregate.Abstractions;
using Sports.Domain.TennisAggregate.Handlers;
using System;
using Xunit;

namespace Sports.Domain.Tests.Domain.TennisHandlerTests
{
    public class TennisHandlerTestBase
    {
        protected TennisHandler _tennisHandler;
        protected Mock<ITennisRepository> _mockTennisRepository;
        protected Mock<ILogger<TennisHandler>> _mockLogger;

        public TennisHandlerTestBase()
        {
            _mockTennisRepository = new Mock<ITennisRepository>();
            _mockLogger = new Mock<ILogger<TennisHandler>>();
            _tennisHandler = new TennisHandler(_mockTennisRepository.Object, _mockLogger.Object);
        }

        [Fact]
        public void Constructor_WhenNullRepository_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() => new TennisHandler(null, _mockLogger.Object));
        }

        [Fact]
        public void Constructor_WhenNullLogger_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() => new TennisHandler(_mockTennisRepository.Object, null));
        }
    }
}
