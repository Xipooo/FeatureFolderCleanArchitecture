using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.Contributors.Domain.GetContributorById;

public record GetContributorByIdQuery(int ContributorId) : IQuery<Result<ContributorDTO>>;
