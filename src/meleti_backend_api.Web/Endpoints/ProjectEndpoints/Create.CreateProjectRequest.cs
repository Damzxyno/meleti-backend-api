using System.ComponentModel.DataAnnotations;

namespace meleti_backend_api.Web.Endpoints.ProjectEndpoints;

public class CreateProjectRequest
{
  public const string Route = "/Projects";

  [Required]
  public string? Name { get; set; }
}
