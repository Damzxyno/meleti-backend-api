using Ardalis.ApiEndpoints;
using meleti_backend_api.Core.ProjectAggregate;
using meleti_backend_api.Core.ProjectAggregate.Specifications;
using meleti_backend_api.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace meleti_backend_api.Web.Endpoints.ProjectEndpoints;

public class GetById : EndpointBaseAsync
  .WithRequest<GetProjectByIdRequest>
  .WithActionResult<GetProjectByIdResponse>
{
  private readonly IRepository<Project> _repository;

  public GetById(IRepository<Project> repository)
  {
    _repository = repository;
  }

  [HttpGet(GetProjectByIdRequest.Route)]
  [SwaggerOperation(
    Summary = "Gets a single Project",
    Description = "Gets a single Project by Id",
    OperationId = "Projects.GetById",
    Tags = new[] { "ProjectEndpoints" })
  ]
  public override async Task<ActionResult<GetProjectByIdResponse>> HandleAsync(
    [FromRoute] GetProjectByIdRequest request,
    CancellationToken cancellationToken = new())
  {
    var spec = new ProjectByIdWithItemsSpec(request.ProjectId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null)
    {
      return NotFound();
    }

    var response = new GetProjectByIdResponse
    (
      id: entity.Id,
      name: entity.Name,
      items: entity.Items.Select(item => new ToDoItemRecord(item.Id, item.Title, item.Description, item.IsDone))
        .ToList()
    );

    return Ok(response);
  }
}
