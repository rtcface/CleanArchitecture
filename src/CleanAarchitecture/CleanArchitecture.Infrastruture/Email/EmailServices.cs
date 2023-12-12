

using CleanArchitecture.Application.Abstrations.Email;

namespace CleanArchitecture.Infrastruture.Email
{
    internal sealed class EmailServices : IEmailService
    {
        public Task SendAsync(Domain.Users.Email recipient, string subject, string body)
        {
            return Task.CompletedTask;
        }
    }
}