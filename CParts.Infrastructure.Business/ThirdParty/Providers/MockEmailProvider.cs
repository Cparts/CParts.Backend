using System.Threading.Tasks;
using CParts.Business.Abstractions.ThirdParty.Providers;

namespace CParts.Infrastructure.Business.ThirdParty.Providers
{
    public class MockEmailProvider : IEmailProvider
    {
        public async Task<bool> SendAsync(string receiver, string payload)
        {
            return true;
        }
    }
}