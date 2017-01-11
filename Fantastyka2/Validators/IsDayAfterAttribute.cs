using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Fantastyka.Validators
{
    public sealed class IsDateAfterAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly string _testedPropertyName;
        private readonly bool _allowEqualDates;

        public IsDateAfterAttribute(string testedPropertyName, bool allowEqualDates = false)
        {
            this._testedPropertyName = testedPropertyName;
            this._allowEqualDates = allowEqualDates;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyTestedInfo = validationContext.ObjectType.GetProperty(this._testedPropertyName);
            if (propertyTestedInfo == null)
            {
                return new ValidationResult(string.Format("unknown property {0}", this._testedPropertyName));
            }

            var propertyTestedValue = propertyTestedInfo.GetValue(validationContext.ObjectInstance, null);

            if (value == null || !(value is DateTime))
            {
                return ValidationResult.Success;
            }

            if (propertyTestedValue == null || !(propertyTestedValue is DateTime))
            {
                return ValidationResult.Success;
            }

            // Compare values
            if ((DateTime) value >= (DateTime) propertyTestedValue)
            {
                if (this._allowEqualDates && value == propertyTestedValue)
                {
                    return ValidationResult.Success;
                }
                else if ((DateTime) value > (DateTime) propertyTestedValue)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult("Data przeczytania nie może być wcześniejsza niż data zakupu");
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata,
            ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = "Data przeczytania nie może być wcześniejsza niż data zakupu",
                ValidationType = "isdateafter"
            };
            rule.ValidationParameters["propertytested"] = this._testedPropertyName;
            rule.ValidationParameters["allowequaldates"] = this._allowEqualDates;
            yield return rule;
        }
    }
}