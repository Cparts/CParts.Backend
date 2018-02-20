using System.Threading.Tasks;

namespace CParts.Business.Abstractions.ThirdParty
{
    public interface IEmailService
    {
        Task<bool> SendForgetPasswordTokenAsync(string email, string token);
    }
}