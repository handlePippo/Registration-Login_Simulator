using ClubMembershipApplication.Data.Registration;
using ClubMembershipApplication.FieldValidators.Field;
using FieldValidatoriAPI;

namespace ClubMembershipApplication.FieldValidators.User
{
    public class UserRegistrationValidator : IFieldValidator
    {
        private const int FirstName_Min_Length = 2;
        private const int FirstName_Max_Length = 20;
        private const int LastName_Min_Length = 2;
        private const int LastName_Max_Length = 20;

        delegate bool EmailExistsDel(string email);
        private EmailExistsDel _emailExistsDel = null;
        private IRegister _register = null;

        private FieldValidatorDel _fieldValidatorDel = null;

        private RequiredValidDelegate _requiredValidDel = null;
        private StringLengValidDelegate _stringLengValidDel = null;
        private DateValidDelegate _dateValidDel = null;
        private PatternMatchDelegate _patternMatchValidDel = null;
        private CompareFieldsValidDelegate _compareFieldsValidDel;
        private string[] _fieldArray = null;


        public string[] FieldArray
        {
            get
            {
                _fieldArray ??= new string[Enum.GetValues(typeof(FieldConstants.UserRegistrationField)).Length];
                return _fieldArray;
            }
        }

        public FieldValidatorDel ValidatorDel => _fieldValidatorDel;

        //Constructor
        public UserRegistrationValidator(IRegister register) => _register = register;

        public void InitializeValidatorDelegates()
        {
            _fieldValidatorDel = new FieldValidatorDel(ValidField);
            _emailExistsDel = new EmailExistsDel(_register.EmailExists);
            _requiredValidDel = CommonFieldValidatorFunctions.RequiredFieldValidDel;
            _stringLengValidDel = CommonFieldValidatorFunctions.StringLengthValidDel;
            _dateValidDel = CommonFieldValidatorFunctions.DateValidDel;
            _patternMatchValidDel = CommonFieldValidatorFunctions.PatternMatchValidDel;
            _compareFieldsValidDel = CommonFieldValidatorFunctions.CompareFieldsValidDel;
        }


        private bool ValidField(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage)
        {
            fieldInvalidMessage = string.Empty;

            FieldConstants.UserRegistrationField userRegistrationFields = (FieldConstants.UserRegistrationField)fieldIndex;

            switch (userRegistrationFields)
            {
                case FieldConstants.UserRegistrationField.EmailAddress:
                    fieldInvalidMessage = !_requiredValidDel(fieldValue) ? $"You must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationFields)}{Environment.NewLine}" : fieldInvalidMessage;
                    fieldInvalidMessage = fieldInvalidMessage == string.Empty && !_patternMatchValidDel(fieldValue, CommonRegExValidationPattern.Email_Address_RegEx_Pattern) ? $"You must enter a valid email address{Environment.NewLine}" : fieldInvalidMessage;
                    fieldInvalidMessage = fieldInvalidMessage == string.Empty && _emailExistsDel(fieldValue) ? $"This email address already exists!{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.FirstName:
                    fieldInvalidMessage = !_requiredValidDel(fieldValue) ? $"You must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationFields)}{Environment.NewLine}" : fieldInvalidMessage;
                    fieldInvalidMessage = fieldInvalidMessage == string.Empty && !_stringLengValidDel(fieldValue, FirstName_Min_Length, FirstName_Max_Length) ? $"The first name must between {FirstName_Min_Length} and {FirstName_Max_Length} chars{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.LastName:
                    fieldInvalidMessage = !_requiredValidDel(fieldValue) ? $"You must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationFields)}{Environment.NewLine}" : fieldInvalidMessage;
                    fieldInvalidMessage = fieldInvalidMessage == string.Empty && !_stringLengValidDel(fieldValue, LastName_Min_Length, LastName_Max_Length) ? $"The last name must between {LastName_Min_Length} and {LastName_Max_Length} chars{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.Password:
                    fieldInvalidMessage = !_requiredValidDel(fieldValue) ? $"You must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationFields)}{Environment.NewLine}" : fieldInvalidMessage;
                    fieldInvalidMessage = fieldInvalidMessage == string.Empty && !_patternMatchValidDel(fieldValue, CommonRegExValidationPattern.Strong_Password_RegEx_Pattern) ? $"Your password must contain at least 1 small-case letter, 1 capital letter, 1 special char and the total length must be between 6 - 10 chars{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.PasswordCompare:
                    fieldInvalidMessage = !_requiredValidDel(fieldValue) ? $"You must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationFields)}{Environment.NewLine}" : fieldInvalidMessage;
                    fieldInvalidMessage = fieldInvalidMessage == string.Empty && !_compareFieldsValidDel(fieldValue, fieldArray[(int)FieldConstants.UserRegistrationField.Password]) ? $"Your entry didn't match your password{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.DateOfBirth:
                    fieldInvalidMessage = !_requiredValidDel(fieldValue) ? $"You must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationFields)}{Environment.NewLine}" : fieldInvalidMessage;
                    fieldInvalidMessage = fieldInvalidMessage == string.Empty && !_dateValidDel(fieldValue, out DateTime validDateTime) ? $"You didn't enter a valid date{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.PhoneNumber:
                    fieldInvalidMessage = !_requiredValidDel(fieldValue) ? $"You must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationFields)}{Environment.NewLine}" : fieldInvalidMessage;
                    fieldInvalidMessage = fieldInvalidMessage == string.Empty && !_patternMatchValidDel(fieldValue, CommonRegExValidationPattern.Uk_PhoneNumber_RegEx_Pattern) ? $"You didn't enter a valid UK phone number{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.AddressFirstLine:
                    fieldInvalidMessage = !_requiredValidDel(fieldValue) ? $"You must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationFields)}{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.AddressSecondLine:
                    fieldInvalidMessage = !_requiredValidDel(fieldValue) ? $"You must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationFields)}{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.AddressCity:
                    fieldInvalidMessage = !_requiredValidDel(fieldValue) ? $"You must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationFields)}{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.PostCode:
                    fieldInvalidMessage = !_requiredValidDel(fieldValue) ? $"You must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationFields)}{Environment.NewLine}" : fieldInvalidMessage;
                    fieldInvalidMessage = fieldInvalidMessage == string.Empty && !_patternMatchValidDel(fieldValue, CommonRegExValidationPattern.Uk_Post_Code_RegEx_Pattern) ? $"You didn't enter a valid UK post code{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                default: throw new ArgumentException("This field doesen't exist!");
            }

            return fieldInvalidMessage == string.Empty;
        }
    }
}
