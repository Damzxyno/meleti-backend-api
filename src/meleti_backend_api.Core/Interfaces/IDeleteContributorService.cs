using Ardalis.Result;

namespace meleti_backend_api.Core.Interfaces;

public interface IDeleteContributorService
{
    public Task<Result> DeleteContributor(int contributorId);
}
