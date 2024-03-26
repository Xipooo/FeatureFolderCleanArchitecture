using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Contributors.Domain.UpdateContributor;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class UpdateContributorEndpointRequestValidator : Validator<UpdateContributorEndpointRequest>
{
  public UpdateContributorEndpointRequestValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(2)
      .MaximumLength(Constants.DEFAULT_NAME_LENGTH);
    RuleFor(x => x.ContributorId)
      .Must((args, contributorId) => args.Id == contributorId)
      .WithMessage("Route and body Ids must match; cannot update Id of an existing resource.");
  }
}
