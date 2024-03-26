using Clean.Architecture.Email.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Clean.Architecture.Contributors.Domain.DeleteContributor;

/// <summary>
/// NOTE: Internal because ContributorDeleted is also marked as internal.
/// </summary>
internal class DeletedContributorEventHandler(ILogger<DeletedContributorEventHandler> logger,
  IEmailSender emailSender) : INotificationHandler<DeletedContributorEvent>
{
  public async Task Handle(DeletedContributorEvent domainEvent, CancellationToken cancellationToken)
  {
    logger.LogInformation("Handling Contributed Deleted event for {contributorId}", domainEvent.ContributorId);

    await emailSender.SendEmailAsync("to@test.com",
                                     "from@test.com",
                                     "Contributor Deleted",
                                     $"Contributor with id {domainEvent.ContributorId} was deleted.");
  }
}
