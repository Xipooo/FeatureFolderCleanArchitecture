using FastEndpoints;
using MediatR;

namespace Clean.Architecture.Contributors.Domain.CreateContributor;

/// <summary>
/// CreateContributorEndpoint a new Contributor
/// </summary>
/// <remarks>
/// Creates a new Contributor given a name.
/// </remarks>
public class CreateContributorEndpoint(IMediator _mediator)
  : Endpoint<CreateContributorEndpointRequest, CreateContributorEndpointResponse>
{
  public override void Configure()
  {
    Post(CreateContributorEndpointRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      // XML Docs are used by default but are overridden by these properties:
      //s.Summary = "CreateContributorEndpoint a new Contributor.";
      //s.Description = "CreateContributorEndpoint a new Contributor. A valid name is required.";
      s.ExampleRequest = new CreateContributorEndpointRequest { Name = "Contributor Name" };
    });
  }

  public override async Task HandleAsync(
    CreateContributorEndpointRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreateContributorCommand(request.Name!,
      request.PhoneNumber));

    if (result.IsSuccess)
    {
      Response = new CreateContributorEndpointResponse(result.Value, request.Name!);
      return;
    }
    // TODO: Handle other cases as necessary
  }
}
