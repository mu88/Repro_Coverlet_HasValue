using FluentAssertions;
using Logic;
using NSubstitute;

namespace Tests;

public class ServiceExtensionsTests
{
    [Fact]
    public void IsInPast_ShouldBeTrue_WhenServiceHasNoTime()
    {
        // Arrange
        var service = Substitute.For<IService>();
        service.GetTime().Returns((TimeOnly?)null);

        // Act
        var result = service.IsInPast();

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void IsInPast_ShouldBeTrue_WhenTimeIsInPast()
    {
        // Arrange
        var service = Substitute.For<IService>();
        service.GetTime().Returns(new TimeOnly(0, 0));

        // Act
        var result = service.IsInPast();

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void IsInPast_ShouldBeFalse_WhenTimeIsInFuture()
    {
        // Arrange
        var service = Substitute.For<IService>();
        service.GetTime().Returns(new TimeOnly(23, 59));

        // Act
        var result = service.IsInPast();

        // Assert
        result.Should().BeFalse();
    }
}