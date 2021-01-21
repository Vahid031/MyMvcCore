using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Infrastructure.Validation
{
    public class IranianNationalCode : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string[] allDigitEqual = new[] { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444",
            "5555555555", "6666666666", "7777777777", "8888888888", "9999999999", "0123456789" };

            if (string.IsNullOrEmpty(value?.ToString()))
                return ValidationResult.Success;

            try
            {
                var chArray = value.ToString().ToCharArray();

                var a = Convert.ToInt32(chArray[9].ToString());
                var b = Convert.ToInt32(chArray[0].ToString()) * 10 +
                        Convert.ToInt32(chArray[1].ToString()) * 9 +
                        Convert.ToInt32(chArray[2].ToString()) * 8 +
                        Convert.ToInt32(chArray[3].ToString()) * 7 +
                        Convert.ToInt32(chArray[4].ToString()) * 6 +
                        Convert.ToInt32(chArray[5].ToString()) * 5 +
                        Convert.ToInt32(chArray[6].ToString()) * 4 +
                        Convert.ToInt32(chArray[7].ToString()) * 3 +
                        Convert.ToInt32(chArray[8].ToString()) * 2;

                b %= 11;
                b -= (b >= 2) ? 11 : 0;

                if (!allDigitEqual.Contains(value.ToString()) && a == Math.Abs(b))
                {
                    return ValidationResult.Success;
                }
            }
            catch
            { }

            return new ValidationResult(ErrorMessage);


        }

        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-iranianNationalCode", GetErrorMessage());
        }

        public string GetErrorMessage() => ErrorMessage;

        private bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (attributes.ContainsKey(key))
                return false;

            attributes.Add(key, value);
            return true;
        }

    }
}
