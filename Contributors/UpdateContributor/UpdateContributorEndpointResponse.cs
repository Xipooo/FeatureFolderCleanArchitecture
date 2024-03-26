namespace Clean.Architecture.Contributors.Domain.UpdateContributor;

public class UpdateContributorEndpointResponse(ContributorRecord contributor)
{
  public ContributorRecord Contributor { get; set; } = contributor;
}
