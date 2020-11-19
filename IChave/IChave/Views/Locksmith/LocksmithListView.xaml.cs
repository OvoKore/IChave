using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using NavigationPage = Xamarin.Forms.NavigationPage;

namespace IChave.Views.Locksmith
{
    public partial class LocksmithListView : ContentPage
    {
        public LocksmithListView()
        {
            InitializeComponent();
            Title = "Locksmith";
            IconImageSource = ImageSource.FromFile("demand.png");
            NavigationPage.SetHasNavigationBar(this, false);
            On<iOS>().SetUseSafeArea(true);
        }
    }
}