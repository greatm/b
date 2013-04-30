using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace b.Validations
{
    public class MaxWordsAttribute : ValidationAttribute, IClientValidatable
    {
        public int MaxWords { get; set; }
        public MaxWordsAttribute(int maxWords)
            : base("Too many words in {0}")
        {
            MaxWords = maxWords;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var wordCount = value.ToString().Split(' ').Length;
                if (wordCount > MaxWords)
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
            }
            return ValidationResult.Success;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationParameters.Add("maxwords", MaxWords);
            rule.ValidationType = "maxwords";
            yield return rule;
        }
    }
}