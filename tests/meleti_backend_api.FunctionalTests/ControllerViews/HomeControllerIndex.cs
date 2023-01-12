using meleti_backend_api.Web;
using Xunit;

namespace meleti_backend_api.FunctionalTests.ControllerViews;

[Collection("Sequential")]
public class HomeControllerIndex : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  public HomeControllerIndex(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnsViewWithCorrectMessage()
  {
    HttpResponseMessage response = await _client.GetAsync("/");
    response.EnsureSuccessStatusCode();
    string stringResponse = await response.Content.ReadAsStringAsync();

    Assert.Contains("meleti_backend_api.Web", stringResponse);
  }
}
