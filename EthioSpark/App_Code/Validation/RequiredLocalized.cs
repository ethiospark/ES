using System.ComponentModel.DataAnnotations;

namespace EthioSpark.Validation
{
    public class RequiredLocalizedAttribute : RequiredAttribute
    {
        public RequiredLocalizedAttribute()
        {
            ErrorMessageResourceType = typeof(StringResources);
        }
    }
}
