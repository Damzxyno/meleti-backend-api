using System.Threading.Tasks;

namespace meleti_backend_api.Core.Interfaces;

public interface IEmailSender
{
  Task SendEmailAsync(string to, string from, string subject, string body);
}
