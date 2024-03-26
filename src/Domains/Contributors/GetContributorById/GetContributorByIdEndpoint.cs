using Ardalis.Result;
using FastEndpoints;
using MediatR;

namespace Clean.Architecture.Contributors.Domain.GetContributorById;

/// <summary>
/// Get a Contributor by integer ID.
/// </summary>
/// <remarks>
/// Takes a positive integer ID and returns a matching Contributor record.
/// </remarks>
public class GetContributorByIdEndpoint(IMediator _mediator)
  : Endpoint<GetContributorByIdEndpointRequest, ContributorRecord>
{
  public override void Configure()
  {
    Get(GetContributorByIdEndpointRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetContributorByIdEndpointRequest request,
    CancellationToken cancellationToken)
  {
    var command = new GetContributorByIdQuery(request.ContributorId);

    var result = await _mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new ContributorRecord(result.Value.Id, result.Value.Name, result.Value.PhoneNumber);
    }
  }
}
