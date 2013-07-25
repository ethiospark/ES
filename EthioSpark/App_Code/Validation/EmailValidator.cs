using System.ComponentModel.DataAnnotations;

namespace EthioSpark.Validation
{

    public class EmailValidatorAttribute : RegularExpressionAttribute
    {
        public EmailValidatorAttribute(): base(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}")
        {
            ErrorMessageResourceType = typeof (StringResources);
            ErrorMessageResourceName = "InvalidEmail";
        }
    }

}