using Ardalis.Specification;

namespace Clean.Architecture.Contributors.Domain.GetContributorById;

public class GetContributorByIdSpec : Specification<Contributor>
{
  public GetContributorByIdSpec(int contributorId)
  {
    Query
        .Where(contributor => contributor.Id == contributorId);
  }
}
