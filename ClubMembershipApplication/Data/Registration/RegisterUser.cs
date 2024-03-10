using ClubMembershipApplication.Data.Db_Context;
using ClubMembershipApplication.FieldValidators.Field;
using ClubMembershipApplication.Models;

namespace ClubMembershipApplication.Data.Registration
{
    public class RegisterUser : IRegister
    {

        public bool EmailExists(string email)
        {
            using var dbContext = new ClubMembershipDbContext();
            return dbContext.Users.Any(u => u.Email.Trim().ToLower() == email.Trim().ToLower());
        }

        public bool Register(string[] fields)
        {
            using var dbContext = new ClubMembershipDbContext();
            User user = new()
            {
                Email = fields[(int)FieldConstants.UserRegistrationField.EmailAddress],
                FirstName = fields[(int)FieldConstants.UserRegistrationField.FirstName],
                LastName = fields[(int)FieldConstants.UserRegistrationField.LastName],
                Password = fields[(int)FieldConstants.UserRegistrationField.Password],
                PhoneNumber = fields[(int)FieldConstants.UserRegistrationField.PhoneNumber],
                AddressCity = fields[(int)FieldConstants.UserRegistrationField.AddressCity],
                AddressFirstLine = fields[(int)FieldConstants.UserRegistrationField.AddressFirstLine],
                AddressSecondLine = fields[(int)FieldConstants.UserRegistrationField.AddressSecondLine],
                PostCode = fields[(int)FieldConstants.UserRegistrationField.PostCode],
                DateOfBirth = DateTime.Parse(fields[(int)FieldConstants.UserRegistrationField.DateOfBirth]),
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return true;
        }
    }
}
