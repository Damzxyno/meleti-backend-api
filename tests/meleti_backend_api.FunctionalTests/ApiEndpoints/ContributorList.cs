using Ardalis.HttpClientTestExtensions;
using meleti_backend_api.Web;
using meleti_backend_api.Web.Endpoints.ContributorEndpoints;
using Xunit;

namespace meleti_backend_api.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class ContributorList : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  public ContributorList(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnsTwoContributors()
  {
    var result = await _client.GetAndDeserializeAsync<ContributorListResponse>("/Contributors");

    Assert.Equal(2, result.Contributors.Count);
    Assert.Contains(result.Contributors, i => i.Name == SeedData.Contributor1.Name);
    Assert.Contains(result.Contributors, i => i.Name == SeedData.Contributor2.Name);
  }
}
