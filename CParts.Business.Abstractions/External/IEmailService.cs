using System.Threading.Tasks;

namespace CParts.Business.Abstractions.External
{
    public interface IEmailService
    {
        Task<bool> SendForgetPasswordTokenAsync(string email, string token);
    }
}