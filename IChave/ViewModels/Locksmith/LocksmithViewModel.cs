using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using IChave.DTO;
using IChave.Models;
using IChave.ViewModels.Base;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Essentials;

namespace IChave.ViewModels.Locksmith
{
    public class LocksmithViewModel : ViewModelTabbedBase
    {
        protected LocksmithViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
        }

        #region
        public LocksmithDTO Locksmith { get; private set; } = new LocksmithDTO();

        public ObservableCollection<Service> Services { get; private set; } = new ObservableCollection<Service>();
        #endregion

        public override void Initialize(INavigationParameters parameters)
        {
            Locksmith = parameters.GetValue<LocksmithDTO>("locksmith");
            Title = Locksmith.company_name;
            GetLocksmithServices();
            HasInitialized = true;
        }

        public override void RefreshAsync()
        {
            GetLocksmithServices();
            IsRefreshing = false;
        }

        public async void GetLocksmithServices()
        {
            try
            {
                IsBusy = true;
                var apiRetorno = await Utils.GetApi().GetLocksmithServices(Locksmith.locksmith_id);
                Services.Clear();
                foreach (Service s in apiRetorno)
                {
                    Services.Add(s);
                }
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

        private DelegateCommand<Service> whatsAppCommand;
        public DelegateCommand<Service> WhatsAppCommand => whatsAppCommand ??= new DelegateCommand<Service>(async (service) => await WhatsAppAsync(service), (service) => !IsBusy);

        private async Task WhatsAppAsync(Service service)
        {
            try
            {
                string Url = "https://api.whatsapp.com/send?phone=";
                Url += "+55" + Locksmith.cell_phone;
                Url += "&text=" + "ola";
                var a = Launcher.OpenAsync(Url);
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