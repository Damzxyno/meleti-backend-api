using meleti_backend_api.Core.ProjectAggregate;
using meleti_backend_api.Core.ProjectAggregate.Specifications;
using meleti_backend_api.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace meleti_backend_api.Web.Pages.ProjectDetails;

public class IncompleteModel : PageModel
{
  private readonly IRepository<Project> _repository;

  [BindProperty(SupportsGet = true)]
  public int ProjectId { get; set; }

  public List<ToDoItem>? ToDoItems { get; set; }

  public IncompleteModel(IRepository<Project> repository)
  {
    _repository = repository;
  }

  public async Task OnGetAsync()
  {
    var projectSpec = new ProjectByIdWithItemsSpec(ProjectId);
    var project = await _repository.FirstOrDefaultAsync(projectSpec);
    if (project == null)
    {
      return;
    }

    var spec = new IncompleteItemsSpec();

    ToDoItems = spec.Evaluate(project.Items).ToList();
  }
}
