using Ardalis.Result;
using Clean.Architecture.Contributors.Domain.GetContributorById;
using FastEndpoints;
using MediatR;

namespace Clean.Architecture.Contributors.Domain.UpdateContributor;

/// <summary>
/// UpdateContributorEndpoint an existing Contributor.
/// </summary>
/// <remarks>
/// UpdateContributorEndpoint an existing Contributor by providing a fully defined replacement set of values.
/// See: https://stackoverflow.com/questions/60761955/rest-update-best-practice-put-collection-id-without-id-in-body-vs-put-collecti
/// </remarks>
public class UpdateContributorEndpoint(IMediator _mediator)
  : Endpoint<UpdateContributorEndpointRequest, UpdateContributorEndpointResponse>
{
  public override void Configure()
  {
    Put(UpdateContributorEndpointRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    UpdateContributorEndpointRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new UpdateContributorCommand(request.Id, request.Name!));

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var query = new GetContributorByIdQuery(request.ContributorId);

    var queryResult = await _mediator.Send(query);

    if (queryResult.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (queryResult.IsSuccess)
    {
      var dto = queryResult.Value;
      Response = new UpdateContributorEndpointResponse(new ContributorRecord(dto.Id, dto.Name, dto.PhoneNumber));
      return;
    }
  }
}
