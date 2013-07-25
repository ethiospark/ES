using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using EthioSpark.BuisnessLogic.Enums;
using EthioSpark.Entities;
using EthioSpark.Validation;

namespace EthioSpark.Models
{
    public class RegisterModel
    {
        private DateTime _unixEphoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        [Range(0, 3, ErrorMessageResourceType = typeof (StringResources), ErrorMessageResourceName = "UnexpectedInputValue")]
        public int GenderMode { get; set; }

        [DOBValidator]
        public long BirthDate { get; set; }

        [RequiredLocalized(ErrorMessageResourceName = "NoUsername")]
        [StringLength(128, ErrorMessageResourceType = typeof (StringResources), ErrorMessageResourceName = "UsernameTooLong")]
        public string UserName { get; set; }

        [RequiredLocalized(ErrorMessageResourceName = "NoPassword")]
        [StringLength(128, ErrorMessageResourceType = typeof (StringResources), ErrorMessageResourceName = "PasswordTooLong")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [RequiredLocalized(ErrorMessageResourceName = "NoPasswordConfirmation")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessageResourceName = "PasswordConfirmationNotMatching", ErrorMessageResourceType = typeof(StringResources))]
        public string ConfirmPassword { get; set; }

        [RequiredLocalized(ErrorMessageResourceName = "NoEmail")]
        [EmailValidator]
        [StringLength(128, ErrorMessageResourceType = typeof (StringResources), ErrorMessageResourceName = "EmailTooLong")]
        public string Email { get; set; }


        public DateTime DateOfBirth
        {
            get
            {
                return _unixEphoch.AddMilliseconds(BirthDate);
            }
        }

        private void GetGenderValues(out GenderType genderType, out GenderType seekingGenderType)
        {
            switch (GenderMode)
            {
                case 1:
                    genderType = GenderType.Female;
                    seekingGenderType = GenderType.Male;
                    break;
                case 2:
                    genderType = GenderType.Female;
                    seekingGenderType = GenderType.Female;
                    break;
                case 3:
                    genderType = GenderType.Male;
                    seekingGenderType = GenderType.Male;
                    break;
                default:
                    genderType = GenderType.Male;
                    seekingGenderType = GenderType.Female;
                    break;
            }
        }

        public User InitUser()
        {
            GenderType genderType;
            GenderType seekingGenderType;
            GetGenderValues(out genderType, out seekingGenderType);
            return new User
                        {
                            Dob = DateOfBirth,
                            Gender = (sbyte) genderType,
                            SeekingGender = (sbyte) seekingGenderType
                        };

        }
    }
}