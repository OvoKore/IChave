using IChave.ViewModels.Base;
using Prism.Navigation;
using Prism.Services;

namespace IChave.ViewModels.Historic
{
    public class HistoricViewModel : ViewModelTabbedBase
    {
        protected HistoricViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
        }
    }
}