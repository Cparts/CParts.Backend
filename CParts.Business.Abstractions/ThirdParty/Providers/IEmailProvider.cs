using System.Threading.Tasks;

namespace CParts.Business.Abstractions.ThirdParty.Providers
{
    public interface IEmailProvider
    {
        Task<bool> SendAsync(string receiver, string payload);
    }
}