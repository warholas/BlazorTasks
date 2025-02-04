using Bunit;
using Xunit;
using BlazorTasks.Pages;
using Moq;
using Blazored.LocalStorage;
using BlazorTasks.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography.X509Certificates;
namespace BlazorTasks.UnitTests.Pages;
public class HomeTests : TestContext
{
    private readonly Mock<ILocalStorageService> _localStorageMock;

    public HomeTests()
    {
        _localStorageMock = new Mock<ILocalStorageService>();
        Services.AddSingleton(_localStorageMock.Object);
    }

    [Fact]
    public void HomePage_Should_Render_Correctly()
    {
        // Arrange
        // Mock the GetItemAsync method to return an empty list of tasks
        _localStorageMock.Setup(x => x.GetItemAsync<List<TaskItem>>("tasks", It.IsAny<CancellationToken>())).ReturnsAsync(new List<TaskItem>());

        // Act
        var cut = RenderComponent<Home>();
        // find h1 element
        var h1 = cut.Find("h1").TextContent;

        // Assert
        Assert.Equal("Tasks", h1);  
    }

}
