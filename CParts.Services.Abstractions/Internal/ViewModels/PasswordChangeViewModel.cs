using CParts.Domain.Core.Model.Internal;

namespace CParts.Services.Abstractions.Internal.ViewModels
{
    public class PasswordChangeViewModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public ApplicationUser User { get; set; }
    }
}