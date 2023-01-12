using Ardalis.Specification.EntityFrameworkCore;
using meleti_backend_api.SharedKernel.Interfaces;

namespace meleti_backend_api.Infrastructure.Data;

// inherit from Ardalis.Specification type
public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
  public EfRepository(AppDbContext dbContext) : base(dbContext)
  {
  }
}
