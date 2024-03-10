using ClubMembershipApplication.Commons;
using ClubMembershipApplication.FieldValidators.Field;

namespace ClubMembershipApplication.Views
{
    public class MainView : IView
    {
        public IFieldValidator FieldValidator => null;

        private IView _registerView, _loginView;

        public MainView(IView registerView, IView loginView )
        {
            this._registerView = registerView;
            this._loginView = loginView;
        }

        public void RunView()
        {
            CommonOutputText.WriteMainHeading();

            Console.WriteLine("Please press 'l' to Login, or press 'r' to register");

            ConsoleKey key = Console.ReadKey().Key;

            if(key == ConsoleKey.R)
            {
                RunUserRegistrationView();
                RunUserLoginView();
            }
            else if(key == ConsoleKey.L)
            {
                RunUserLoginView();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Goodbye");
                Console.ReadKey();
            }
        }

        private void RunUserRegistrationView()
        {
            this._registerView.RunView();
        }

        private void RunUserLoginView()
        {
            this._loginView.RunView();
        }
    }
}
