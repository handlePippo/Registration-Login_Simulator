using ClubMembershipApplication.Data.Login;
using ClubMembershipApplication.Data.Registration;
using ClubMembershipApplication.FieldValidators.Field;
using ClubMembershipApplication.FieldValidators.User;
using ClubMembershipApplication.Views;

namespace ClubMembershipApplication.Commons
{
    public static class Factory
    {
        public static IView GetMainViewObject()
        {
            ILogin login = new LoginUser();
            IRegister register = new RegisterUser();
            IFieldValidator userRegistrationValidator = new UserRegistrationValidator(register);
            userRegistrationValidator.InitializeValidatorDelegates();

            IView registerView = new UserRegistrationView(register, userRegistrationValidator);
            IView loginView = new UserLoginView(login);
            IView mainView = new MainView(registerView, loginView);

            return mainView;
        }
    }
}
