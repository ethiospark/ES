using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace EthioSpark.Validation
{
    public class DOBValidatorAttribute : ValidationAttribute
    {
        private readonly int _yearLookbackEnd;
        private readonly int _yearLookbackStart;

        public DOBValidatorAttribute()
        {
            if (!int.TryParse(ConfigurationManager.AppSettings["AgeStartYear"], out _yearLookbackStart))
                _yearLookbackStart = 18;
            if (!int.TryParse(ConfigurationManager.AppSettings["AgeEndYear"], out _yearLookbackEnd))
                _yearLookbackEnd = 100;
        }


        public override bool IsValid(object msSinceEpoch)
        {
            bool isValid = false;
            ErrorMessage = StringResources.InvalidDOB;

            if (msSinceEpoch is long)
            {
                //dates are expected to be in UTC(milliseconds since Ephoch).
                DateTime date = new DateTime(1970, 1, 1).AddTicks(Convert.ToInt64(msSinceEpoch) * 10000);
                if (_yearLookbackEnd > 0 || _yearLookbackStart > 0)
                {
                    //check range if applicable.
                    if (_yearLookbackStart > 0)
                    {
                        isValid = (date <= DateTime.Now.AddYears(-1 * _yearLookbackStart));
                        if (!isValid)
                        {
                            ErrorMessage = string.Format(StringResources.AgeTooYoung, _yearLookbackStart, StringResources.CompanySite);
                        }
                    }

                    if (isValid && _yearLookbackEnd > 0)
                    {
                        isValid = (date >= DateTime.Now.AddYears(-1 * _yearLookbackEnd));
                    }
                }
                else
                {
                    isValid = true;
                }
            }
            return isValid;
        }
    }
}