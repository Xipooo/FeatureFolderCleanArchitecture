namespace Clean.Architecture.Contributors.Domain.ListContributors;

/// <summary>
/// Represents a service that will actually fetch the necessary data
/// Typically implemented in Infrastructure
/// </summary>
public interface IListContributorsQueryService
{
  Task<IEnumerable<ContributorDTO>> ListAsync();
}
