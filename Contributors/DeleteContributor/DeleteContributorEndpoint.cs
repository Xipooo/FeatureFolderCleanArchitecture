using Ardalis.Result;
using FastEndpoints;
using MediatR;

namespace Clean.Architecture.Contributors.Domain.DeleteContributor;

/// <summary>
/// DeleteContributorEndpoint a Contributor.
/// </summary>
/// <remarks>
/// DeleteContributorEndpoint a Contributor by providing a valid integer id.
/// </remarks>
public class DeleteContributorEndpoint(IMediator _mediator)
  : Endpoint<DeleteContributorEndpointRequest>
{
  public override void Configure()
  {
    Delete(DeleteContributorEndpointRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    DeleteContributorEndpointRequest request,
    CancellationToken cancellationToken)
  {
    var command = new DeleteContributorCommand(request.ContributorId);

    var result = await _mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      await SendNoContentAsync(cancellationToken);
    };
    // TODO: Handle other issues as needed
  }
}
