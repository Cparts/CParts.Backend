using System.Threading.Tasks;

namespace CParts.Business.Abstractions.External.Providers
{
    public interface IEmailProvider
    {
        Task<bool> SendAsync(string receiver, string payload);
    }
}