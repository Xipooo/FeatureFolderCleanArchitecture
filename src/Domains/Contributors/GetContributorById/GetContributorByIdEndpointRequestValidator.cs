using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Contributors.Domain.GetContributorById;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class GetContributorByIdEndpointRequestValidator : Validator<GetContributorByIdEndpointRequest>
{
  public GetContributorByIdEndpointRequestValidator()
  {
    RuleFor(x => x.ContributorId)
      .GreaterThan(0);
  }
}
