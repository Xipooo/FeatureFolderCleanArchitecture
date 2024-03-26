using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.Contributors.Domain.DeleteContributor;

public record DeleteContributorCommand(int ContributorId) : ICommand<Result>;
