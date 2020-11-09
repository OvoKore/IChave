using IChave.Controls;
using IChave.Views.Configurations;
using IChave.Views.Historic;
using IChave.Views.Locksmith;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using TabbedPage = Xamarin.Forms.TabbedPage;

namespace IChave.Views
{
    public partial class MenuView : TabbedPage
    {
        public MenuView()
        {
            InitializeComponent();
            On<iOS>().SetUseSafeArea(true);
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            On<Android>().SetIsSmoothScrollEnabled(false);

            Children.Add(new CustomNavigationPage(new LocksmithListView()));
            Children.Add(new CustomNavigationPage(new HistoricView()));
            Children.Add(new CustomNavigationPage(new ConfigView()));
        }
    }
}