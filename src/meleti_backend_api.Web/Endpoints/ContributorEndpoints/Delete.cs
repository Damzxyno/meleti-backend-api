﻿using FastEndpoints;
using Ardalis.Result;
using meleti_backend_api.Core.Interfaces;

namespace meleti_backend_api.Web.Endpoints.ContributorEndpoints;

public class Delete : Endpoint<DeleteContributorRequest>
{

  private readonly IDeleteContributorService _deleteContributorService;

  public Delete(IDeleteContributorService service)
  {
    _deleteContributorService = service;
  }

  public override void Configure()
  {
    Delete(DeleteContributorRequest.Route);
    AllowAnonymous();
    Options(x => x
      .WithTags("ContributorEndpoints"));
  }
  public override async Task HandleAsync(
    DeleteContributorRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _deleteContributorService.DeleteContributor(request.ContributorId);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync();
      return;
    }

    await SendNoContentAsync();
  }
}
