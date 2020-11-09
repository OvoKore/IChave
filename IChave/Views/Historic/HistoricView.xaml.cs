using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using NavigationPage = Xamarin.Forms.NavigationPage;

namespace IChave.Views.Historic
{
    public partial class HistoricView : ContentPage
    {
        public HistoricView()
        {
            InitializeComponent();
            Title = "Historic";
            IconImageSource = ImageSource.FromFile("historic.png");
            NavigationPage.SetHasNavigationBar(this, false);
            On<iOS>().SetUseSafeArea(true);
        }
    }
}