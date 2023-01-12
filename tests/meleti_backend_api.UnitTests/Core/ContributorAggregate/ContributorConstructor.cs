using meleti_backend_api.Core.ContributorAggregate;
using Xunit;

namespace meleti_backend_api.UnitTests.Core.ContributorAggregate;

public class ContributorConstructor
{
  private readonly string _testName = "test name";
  private Contributor? _testContributor;

  private Contributor CreateContributor()
  {
    return new Contributor(_testName);
  }

  [Fact]
  public void InitializesName()
  {
    _testContributor = CreateContributor();

    Assert.Equal(_testName, _testContributor.Name);
  }
}
