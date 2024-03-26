using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Contributors.Domain.CreateContributor;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class CreateContributorEndpointRequestValidator : Validator<CreateContributorEndpointRequest>
{
  public CreateContributorEndpointRequestValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(2)
      .MaximumLength(Constants.DEFAULT_NAME_LENGTH);
  }
}
