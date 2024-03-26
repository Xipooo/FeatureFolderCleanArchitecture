using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.Contributors.Domain.CreateContributor;

/// <summary>
/// CreateContributorEndpoint a new Contributor.
/// </summary>
/// <param name="Name"></param>
public record CreateContributorCommand(string Name, string? PhoneNumber) : ICommand<Result<int>>;
