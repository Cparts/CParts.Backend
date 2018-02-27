using System.Threading.Tasks;
using CParts.Business.Abstractions.External;
using CParts.Business.Abstractions.External.Providers;

namespace CParts.Infrastructure.Business.External
{
    public class MockEmailService : IEmailService
    {
        private readonly IEmailProvider _emailProvider;

        public MockEmailService(IEmailProvider emailProvider)
        {
            _emailProvider = emailProvider;
        }

        public async Task<bool> SendForgetPasswordTokenAsync(string email, string token)
        {
            return await _emailProvider.SendAsync(email, $"some usefulprofound text http://somesite:someport/resetpassword?token={token}");
        }
    }
}