using Ardalis.GuardClauses;
using meleti_backend_api.SharedKernel;
using meleti_backend_api.SharedKernel.Interfaces;

namespace meleti_backend_api.Core.ContributorAggregate;

public class Contributor : EntityBase, IAggregateRoot
{
  public string Name { get; private set; }

  public Contributor(string name)
  {
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
  }

  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }
}
