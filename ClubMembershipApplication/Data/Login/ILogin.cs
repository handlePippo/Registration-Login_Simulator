using ClubMembershipApplication.Models;

namespace ClubMembershipApplication.Data.Login
{
    public interface ILogin
    {
        User Login(string username, string password);
    }
}
