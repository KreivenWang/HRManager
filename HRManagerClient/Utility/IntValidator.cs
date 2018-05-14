using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Steelsa;

namespace HRManagerClient.Utility
{
    public class IntValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            return RegexValidator.IsInteger((string) value) ? new ValidationResult(true, null) : new ValidationResult(false, "请输入0-9组成的字符串");
        }
    }
}
