using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.Contributors.Domain.ListContributors;

public record ListContributorsQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<ContributorDTO>>>;
