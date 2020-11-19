using IChave.ViewModels.Base;
using IChave.ViewModels.LoginSignUp;
using IChave.Views;
using IChave.Views.LoginSignUp;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using IChave.Views.Configurations;
using IChave.ViewModels.Configurations;
using IChave.ViewModels.Configurations.Address;
using IChave.Views.Configurations.Address;
using IChave.Views.Locksmith;
using IChave.ViewModels.Locksmith;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace IChave
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            VersionTracking.Track();

            await NavigationService.NavigateAsync("/NavigationPage/LoginView");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<MenuView, ViewModelBase>();

            containerRegistry.RegisterForNavigation<LoginView, LoginViewModel>();
            containerRegistry.RegisterForNavigation<SignUpView, SignUpViewModel>();

            containerRegistry.RegisterForNavigation<LocksmithListView, LocksmithListViewModel>();
            containerRegistry.RegisterForNavigation<LocksmithView, LocksmithViewModel>();

            containerRegistry.RegisterForNavigation<ConfigView, ConfigViewModel>();

            containerRegistry.RegisterForNavigation<ProfileView, ProfileViewModel>();
            containerRegistry.RegisterForNavigation<ChangePasswordView, ChangePasswordViewModel>();

            containerRegistry.RegisterForNavigation<AddressView, AddressViewModel>();
            containerRegistry.RegisterForNavigation<NewAddressView, NewAddressViewModel>();

            containerRegistry.RegisterForNavigation<AboutView, AboutViewModel>();
            containerRegistry.RegisterForNavigation<PrivacyView, ViewModelBase>();
            containerRegistry.RegisterForNavigation<TermsUseView, ViewModelBase>();
        }
    }
}