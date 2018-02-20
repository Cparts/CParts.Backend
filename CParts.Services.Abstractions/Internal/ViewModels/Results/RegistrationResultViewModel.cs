namespace CParts.Services.Abstractions.Internal.ViewModels.Results
{
    public class RegistrationResultViewModel
    {
        public static RegistrationResultViewModel Failed(string errors) => new RegistrationResultViewModel
        {
            Succeed = false,
            Errors = errors
        };
        
        public static RegistrationResultViewModel Successful() => new RegistrationResultViewModel
        {
            Succeed = true,
            Errors = null
        };
        
        public bool Succeed { get; protected set; }
        public string Errors { get; protected set; }
    }
}