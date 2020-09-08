using System;
using Xunit;
using web.Controllers;
using Moq;
using Microsoft.Extensions.Logging;

namespace web.Tests
{
    public class WeatherForecastControllerTests
    {
        private readonly WeatherForecastController _controller;

        public WeatherForecastControllerTests()
        {
            var loggerMock = new Mock<ILogger<WeatherForecastController>>();
            _controller = new WeatherForecastController(loggerMock.Object);
        }

        [Fact]
        public void Get_Should_Not_Be_Empty()
        {
            var result = _controller.Get();
            Assert.NotEmpty(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(6)]
        [InlineData(3)]
        public void Get_Should_Not_Return_X_Forecasts(int value)
        {
            var result = _controller.Get();         
            Assert.NotEqual(value, result.Count);
        }

        [Fact]
        public void Get_Should_Return_X_Forecasts()
        {
            var result = _controller.Get();
            Assert.Equal(5, result.Count);
        }
    }
}
