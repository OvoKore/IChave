using Xamarin.Forms;

namespace IChave.Controls
{
    public class CustomNavigationPage : NavigationPage
    {
        public CustomNavigationPage(Page root) : base(root)
        {
            Title = root.Title;
            IconImageSource = root.IconImageSource;
        }

        public CustomNavigationPage()
        {
        }
    }
}
