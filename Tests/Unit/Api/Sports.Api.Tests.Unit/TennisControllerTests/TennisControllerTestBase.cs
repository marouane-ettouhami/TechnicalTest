using Microsoft.Extensions.Logging;
using Moq;
using Sports.Api.TennisFeature.Controllers;
using Sports.Domain.TennisAggregate.Abstractions;
using System;
using Xunit;

namespace Sports.Api.Tests.Unit.TennisControllerTests
{
    /// <summary>
    /// TennisController base tests
    /// </summary>
    public class TennisControllerTestBase
    {
        protected TennisController _tennisController;
        public Mock<ITennisHandler> _mockTennisHandler;
        protected Mock<ILogger<TennisController>> _mockLogger;

        public TennisControllerTestBase()
        {
            _mockTennisHandler = new Mock<ITennisHandler>();
            _mockLogger = new Mock<ILogger<TennisController>>();
            _tennisController = new TennisController(_mockTennisHandler.Object, _mockLogger.Object);
        }

        [Fact]
        public void Constructor_WhenNullHandler_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() => new TennisController(null, _mockLogger.Object));
        }

        [Fact]
        public void Constructor_WhenNullLogger_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() => new TennisController(_mockTennisHandler.Object, null));
        }

    }
}
