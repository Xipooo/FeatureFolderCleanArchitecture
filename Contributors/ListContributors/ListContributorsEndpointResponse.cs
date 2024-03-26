namespace Clean.Architecture.Contributors.Domain.ListContributors;

public class ListContributorsEndpointResponse
{
  public List<ContributorRecord> Contributors { get; set; } = [];
}
