using Ardalis.Result;
using FastEndpoints;
using MediatR;

namespace Clean.Architecture.Contributors.Domain.ListContributors;

/// <summary>
/// ListContributorsEndpoint all Contributors
/// </summary>
/// <remarks>
/// ListContributorsEndpoint all contributors - returns a ListContributorsEndpointResponse containing the Contributors.
/// </remarks>
public class ListContributorsEndpoint(IMediator _mediator) : EndpointWithoutRequest<ListContributorsEndpointResponse>
{
  public override void Configure()
  {
    Get("/Contributors");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    Result<IEnumerable<ContributorDTO>> result = await _mediator.Send(new ListContributorsQuery(null, null));

    if (result.IsSuccess)
    {
      Response = new ListContributorsEndpointResponse
      {
        Contributors = result.Value.Select(c => new ContributorRecord(c.Id, c.Name, c.PhoneNumber)).ToList()
      };
    }
  }
}
