using ClubMembershipApplication.Data.Db_Context;
using ClubMembershipApplication.Models;

namespace ClubMembershipApplication.Data.Login
{
    public class LoginUser : ILogin
    {
        public User Login(string email, string password)
        {
            using var dbContext = new ClubMembershipDbContext();
            User user = dbContext.Users.FirstOrDefault(u => u.Email.ToLower().Trim() == email.ToLower().Trim());
            if (user is null)
            {
                return new User();
            }
            return user;
        }
    }
}
