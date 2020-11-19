using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using IChave.DTO;
using IChave.ViewModels.Base;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace IChave.ViewModels.Locksmith
{
    public class LocksmithListViewModel : ViewModelTabbedBase
    {
        protected LocksmithListViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
        }

        #region
        private LocksmithDTO _selectedLocksmith;
        public LocksmithDTO SelectedLocksmith
        {
            get => _selectedLocksmith;
            set => SetProperty(ref _selectedLocksmith, value);
        }

        public ObservableCollection<LocksmithDTO> Locksmiths { get; private set; } = new ObservableCollection<LocksmithDTO>();
        #endregion

        public override void Initialize(INavigationParameters parameters)
        {
            GetLocksmithList();
            HasInitialized = true;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (HasInitialized)
            {
                GetLocksmithList();
            }
        }

        public override void RefreshAsync()
        {
            GetLocksmithList();
            IsRefreshing = false;
        }

        public async void GetLocksmithList()
        {
            try
            {
                IsBusy = true;
                var apiRetorno = await Utils.GetApi().GetLocksmithList();
                Locksmiths.Clear();
                foreach (LocksmithDTO s in apiRetorno)
                {
                    Locksmiths.Add(s);
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

        private DelegateCommand<LocksmithDTO> editServiceCommand;
        public DelegateCommand<LocksmithDTO> EditServiceCommand => editServiceCommand ??= new DelegateCommand<LocksmithDTO>(async (locksmith) => await OpenLocksmithAsync(locksmith), (locksmith) => !IsBusy);

        private async Task OpenLocksmithAsync(LocksmithDTO locksmith)
        {
            try
            {
                IsBusy = true;
                var navigationParams = new NavigationParameters
                {
                    { "locksmith", locksmith }
                };
                await NavigationWithParameters("LocksmithView", navigationParams);
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