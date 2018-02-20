namespace CParts.Services.Abstractions.Internal.ViewModels.Results
{
    public class SignInResultViewModel
    {
        private const string SuccessMessage = "Successful login";
        private const string FailMessage = "Invalid credentails";
        
        public static SignInResultViewModel Succeed(string token) => new SignInResultViewModel
        (
            success: true,
            token: token,
            message: SuccessMessage
        );
        
        public static SignInResultViewModel Failed() => new SignInResultViewModel
        (
            success: false,
            token: null,
            message: FailMessage
        );

        public bool Success { get; protected set; }
        public string Token { get; protected set; }
        public string Message { get; protected set; }

        private SignInResultViewModel(bool success, string token, string message)
        {
            Success = success;
            Token = token;
            Message = message;
        }
    }
}