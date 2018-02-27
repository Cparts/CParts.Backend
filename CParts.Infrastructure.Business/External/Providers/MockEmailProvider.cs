using System.Threading.Tasks;
using CParts.Business.Abstractions.External.Providers;

namespace CParts.Infrastructure.Business.External.Providers
{
    public class MockEmailProvider : IEmailProvider
    {
        public async Task<bool> SendAsync(string receiver, string payload)
        {
            return true;
        }
    }
}