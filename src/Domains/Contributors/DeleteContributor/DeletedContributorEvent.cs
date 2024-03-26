using Ardalis.SharedKernel;

namespace Clean.Architecture.Contributors.Domain.DeleteContributor;

/// <summary>
/// A domain event that is dispatched whenever a contributor is deleted.
/// The DeleteContributorService is used to dispatch this event.
/// </summary>
internal sealed class DeletedContributorEvent(int contributorId) : DomainEventBase
{
  public int ContributorId { get; init; } = contributorId;
}
