namespace ClubMembershipApplication.Data.Registration
{
    public interface IRegister
    {
        bool Register(string[] fields);
        bool EmailExists(string email);

    }
}
