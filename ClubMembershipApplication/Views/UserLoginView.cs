using ClubMembershipApplication.Commons;
using ClubMembershipApplication.Data.Login;
using ClubMembershipApplication.FieldValidators.Field;
using ClubMembershipApplication.Models;

namespace ClubMembershipApplication.Views
{
    public class UserLoginView : IView
    {
        private readonly ILogin _login = null;
        public UserLoginView(ILogin login) => this._login = login;
        public IFieldValidator FieldValidator => null;


        public void RunView()
        {
            CommonOutputText.WriteMainHeading();
            CommonOutputText.WriteLoginHeading();

            Console.WriteLine("Please enter your email address");
            string emailAddress = Console.ReadLine();


            Console.WriteLine("Please enter your password");
            string password = Console.ReadLine();



            User user = this._login.Login(emailAddress, password);

            if (user is not null && user.Id > 0)
            {
                WelcomeView welcomeView = new(user);
                welcomeView.RunView();
            }
            else
            {
                Console.Clear();
                CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
                Console.WriteLine("The credentials that you entered do not match our records!");
                CommonOutputFormat.ChangeFontColor(FontTheme.Default);
                Console.ReadKey();
            }
        }
    }
}
