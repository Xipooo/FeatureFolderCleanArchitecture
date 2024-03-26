using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Contributors.Domain.DeleteContributor;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class DeleteContributorEndpointRequestValidator : Validator<DeleteContributorEndpointRequest>
{
  public DeleteContributorEndpointRequestValidator()
  {
    RuleFor(x => x.ContributorId)
      .GreaterThan(0);
  }
}
