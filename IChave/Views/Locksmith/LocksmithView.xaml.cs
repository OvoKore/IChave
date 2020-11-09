using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace IChave.Views.Locksmith
{
    public partial class LocksmithView : ContentPage
    {
        public LocksmithView()
        {
            InitializeComponent();
            On<iOS>().SetUseSafeArea(true);
        }
    }
}