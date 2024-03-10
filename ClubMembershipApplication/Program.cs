using ClubMembershipApplication.Commons;
using ClubMembershipApplication.Views;

namespace ClubMembershipApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IView maineView = Factory.GetMainViewObject();
            maineView.RunView();

            Console.ReadKey();
        }
    }
}
