using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CParts.Domain.Core.Model.Internal;

namespace CParts.Services.Abstractions.Internal.ViewModels
{
    public class SignInViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public bool IsPersistant { get; set; } = false;
        
    }
}