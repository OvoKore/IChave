using System;
using System.Threading.Tasks;
using IChave.ModelRealm;
using IChave.ViewModels.Base;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Realms;

namespace IChave.ViewModels.Configurations
{
    public class ConfigViewModel : ViewModelTabbedBase
    {
        protected ConfigViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
        }

        private DelegateCommand aboutCommand;
        public DelegateCommand AboutCommand => aboutCommand ??= new DelegateCommand(async () => await Navigation("AboutView"), () => !IsBusy);

        private DelegateCommand profileCommand;
        public DelegateCommand ProfileCommand => profileCommand ??= new DelegateCommand(async () => await Navigation("ProfileView"), () => !IsBusy);

        private DelegateCommand addressCommand;
        public DelegateCommand AddressCommand => addressCommand ??= new DelegateCommand(async () => await Navigation("AddressView"), () => !IsBusy);

        private DelegateCommand logoutCommand;
        public DelegateCommand LogoutCommand => logoutCommand ??= new DelegateCommand(async () => await LogoutAsync(), () => !IsBusy);

        private async Task LogoutAsync()
        {
            try
            {
                IsBusy = true;
                var realm = Realm.GetInstance();
                realm.Write(() =>
                {
                    realm.RemoveAll<TokenRealm>();
                });
                await NavigationService.NavigateAsync("/NavigationPage/LoginView");
            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync("Erro", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}