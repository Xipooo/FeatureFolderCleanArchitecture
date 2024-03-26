namespace Clean.Architecture.Email.Domain;

public interface IEmailSender
{
  Task SendEmailAsync(string to, string from, string subject, string body);
}
