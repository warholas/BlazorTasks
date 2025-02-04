using Bunit;
using Xunit;
using BlazorTasks.Pages;
namespace BlazorTasks.UnitTests.Pages;
public class HomeTests : TestContext
{
    [Fact]
    public void Home_ShouldRenderCorrectly_WhenInDefaultState()
    {
        // Arrange & Act
        var cut = RenderComponent<Home>();

        // Assert
        cut.MarkupMatches(@"
            <h1>Hello, world!</h1>
            Welcome to your new app.
        ");
    }
}
