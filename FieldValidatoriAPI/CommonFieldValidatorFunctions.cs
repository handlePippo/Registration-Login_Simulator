using System.Text.RegularExpressions;

namespace FieldValidatoriAPI
{
    public delegate bool RequiredValidDelegate(string fieldVal);
    public delegate bool StringLengValidDelegate(string fieldVal, int min, int max);
    public delegate bool DateValidDelegate(string fieldVal, out DateTime validDate);
    public delegate bool PatternMatchDelegate(string fieldVal, string pattern);
    public delegate bool CompareFieldsValidDelegate(string fieldVal, string fieldValCompare);

    public class CommonFieldValidatorFunctions
    {
        private static RequiredValidDelegate _requiredValidDel = null;
        private static StringLengValidDelegate _stringLengValidDel = null;
        private static DateValidDelegate _dateValidDel = null;
        private static PatternMatchDelegate _patternMatchValidDel = null;
        private static CompareFieldsValidDelegate _compareFieldsValidDel = null;


        public static RequiredValidDelegate RequiredFieldValidDel { get => _requiredValidDel ??= new RequiredValidDelegate(RequireFieldValid); }
        public static StringLengValidDelegate StringLengthValidDel
        {
            get
            {
                _stringLengValidDel ??= new StringLengValidDelegate(StringFieldLengthValid);
                return _stringLengValidDel;
            }
        }

        public static DateValidDelegate DateValidDel
        {
            get
            {
                _dateValidDel ??= new DateValidDelegate(DateFieldValid);
                return _dateValidDel;
            }
        }

        public static PatternMatchDelegate PatternMatchValidDel
        {
            get
            {
                _patternMatchValidDel ??= new PatternMatchDelegate(FieldPatternValid);
                return _patternMatchValidDel;
            }
        }

        public static CompareFieldsValidDelegate CompareFieldsValidDel
        {
            get
            {
                _compareFieldsValidDel ??= new CompareFieldsValidDelegate(FieldComparisonValid);
                return _compareFieldsValidDel;
            }
        }

        private static bool RequireFieldValid(string fieldVal) => !string.IsNullOrEmpty(fieldVal);
        private static bool StringFieldLengthValid(string fieldVal, int min, int max) => fieldVal.Length >= min && fieldVal.Length <= max;
        private static bool DateFieldValid(string dateTime, out DateTime validDateTime) => DateTime.TryParse(dateTime, out validDateTime);
        private static bool FieldPatternValid(string fieldVal, string regExPattern) => new Regex(regExPattern).IsMatch(fieldVal);
        private static bool FieldComparisonValid(string field1, string field2) => field1.Equals(field2);
    }
}
