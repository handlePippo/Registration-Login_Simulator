using ClubMembershipApplication.Commons;
using ClubMembershipApplication.FieldValidators.Field;
using ClubMembershipApplication.Models;

namespace ClubMembershipApplication.Views
{
    public class WelcomeView : IView
    {
        private User _user;

        public WelcomeView(User user) => this._user = user;

        public IFieldValidator FieldValidator => null;

        public void RunView()
        {
            Console.Clear();
            CommonOutputText.WriteMainHeading();
            CommonOutputFormat.ChangeFontColor(FontTheme.Success);
            Console.WriteLine($"Welcome, {_user.FirstName} {_user.LastName} to the Cycling Club!");
            CommonOutputFormat.ChangeFontColor(FontTheme.Default);
            Console.ReadKey();
        }
    }
}
