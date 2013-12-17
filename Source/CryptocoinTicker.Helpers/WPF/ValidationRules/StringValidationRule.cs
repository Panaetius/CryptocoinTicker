using System.Globalization;
using System.Windows.Controls;

namespace CryptocoinTicker.Helpers.WPF.ValidationRules
{
    public class StringRangeValidationRule : ValidationRule
    {
        private int _minimumLength = -1;
        private int _maximumLength = -1;

        public int MinimumLength
        {
            get { return _minimumLength; }
            set { _minimumLength = value; }
        }

        public int MaximumLength
        {
            get { return _maximumLength; }
            set { _maximumLength = value; }
        }

        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value,
            CultureInfo cultureInfo)
        {
            var result = new ValidationResult(true, null);
            var inputString = (value ?? string.Empty).ToString();
            if (inputString.Length < this.MinimumLength ||
                   (this.MaximumLength > 0 &&
                    inputString.Length > this.MaximumLength))
            {
                result = new ValidationResult(false, this.ErrorMessage);
            }
            return result;
        }
    }
}