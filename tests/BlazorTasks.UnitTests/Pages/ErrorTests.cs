using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;
using BlazorTasks.Components.Pages;
namespace BlazorTasks.UnitTests.Pages;

public class ErrorTests : TestContext
{
    [Fact]
    public void Error_ShouldDisplayRequestId_WhenRequestIdIsNotNullOrEmpty()
    {
        // Arrange
        var httpContextMock = new Mock<HttpContext>();
        httpContextMock.Setup(c => c.TraceIdentifier).Returns("test-request-id");

        var cut = RenderComponent<Error>(parameters => parameters
            .AddCascadingValue(httpContextMock.Object));

        // Act
        cut.Instance.GetType().GetProperty("RequestId", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.SetValue(cut.Instance, "test-request-id");

        cut.Render();

        // Assert
        cut.Find("code").MarkupMatches("<code>test-request-id</code>");
    }

    [Fact]
    public void Error_ShouldNotDisplayRequestId_WhenRequestIdIsNullOrEmpty()
    {
        // Arrange
        var httpContextMock = new Mock<HttpContext>();
        httpContextMock.Setup(c => c.TraceIdentifier).Returns(string.Empty);

        var cut = RenderComponent<Error>(parameters => parameters
            .AddCascadingValue(httpContextMock.Object));

        // Act
        cut.Instance.GetType().GetProperty("RequestId", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.SetValue(cut.Instance, null);

        cut.Render();

        // Assert
        Assert.Throws<ElementNotFoundException>(() => cut.Find("code"));
    }
}
