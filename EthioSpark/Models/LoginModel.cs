using EthioSpark.Validation;

namespace EthioSpark.Models
{
    public class LoginModel
    {
        [RequiredLocalized(ErrorMessageResourceName = "NoUsername")]
        public string UserName { get; set; }

        [RequiredLocalized(ErrorMessageResourceName = "NoPassword")]
        public string Password { get; set; }
    }
}