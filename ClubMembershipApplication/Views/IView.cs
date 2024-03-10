using ClubMembershipApplication.FieldValidators.Field;

namespace ClubMembershipApplication.Views
{
    public interface IView
    {
        void RunView();
        IFieldValidator FieldValidator { get; }
    }
}
