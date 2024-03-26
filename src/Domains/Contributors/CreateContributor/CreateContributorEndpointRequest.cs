using System.ComponentModel.DataAnnotations;

namespace Clean.Architecture.Contributors.Domain.CreateContributor;

public class CreateContributorEndpointRequest
{
  public const string Route = "/Contributors";

  [Required]
  public string? Name { get; set; }
  public string? PhoneNumber { get; set; }
}
