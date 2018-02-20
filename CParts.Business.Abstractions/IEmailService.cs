using System.Threading.Tasks;

namespace CParts.Business.Abstractions
{
    public interface IEmailService
    {
        Task<bool> SendAsync(string receiver, string payload);
    }
}