using System.Globalization;
using System.Windows.Controls;

namespace CryptocoinTicker.Helpers.WPF.ValidationRules
{
    public class DecimalValidationRule:ValidationRule
    {
        private decimal _maxValue = decimal.MaxValue;
        private decimal _minValue = decimal.MinValue;

        public decimal MaxValue
        {
            get { return _maxValue; }
            set { _maxValue = value; }
        }

        public decimal MinValue
        {
            get { return _minValue; }
            set { _minValue = value; }
        }

        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var inputString = (value ?? string.Empty).ToString();

            decimal parsedNumber;

            if (!decimal.TryParse(inputString, out parsedNumber))
            {
                new ValidationResult(false, this.ErrorMessage);
            }

            if (parsedNumber < MinValue || parsedNumber > MaxValue)
            {
                return new ValidationResult(false, this.ErrorMessage);
            }
            return new ValidationResult(true, null);
        }
    }
}