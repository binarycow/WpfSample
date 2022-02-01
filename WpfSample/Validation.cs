using System.Windows.Controls;

namespace WpfSample
{
    public class StringToIntValidationRule : ValidationRule
    {
        public static readonly ValidationResult InvalidResult = new ValidationResult(false, "Please enter a valid integer value.");
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo) 
            => int.TryParse(value.ToString(), out _) ? ValidationResult.ValidResult : InvalidResult;
    }
    
    public class IntWithinRangeValidationRule : ValidationRule
    {
        public int UpperBound { get; set; } = int.MaxValue;
        public int LowerBound { get; set; } = int.MinValue;
        private bool IsValid(object value)
            => value is int intValue && intValue >= LowerBound && intValue <= UpperBound;
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
            => IsValid(value) 
                ? ValidationResult.ValidResult 
                : new (false, $"Value must be between {LowerBound.ToString()} and {UpperBound.ToString()}");
    }
}