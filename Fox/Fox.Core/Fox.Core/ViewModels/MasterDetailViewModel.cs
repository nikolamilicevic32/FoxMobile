using Fox.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Fox.Core.ViewModels
{
    public class MasterDetailViewModel : MvxViewModel
    {
        readonly INavigationService _navigationService;

        public MasterDetailViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public override async void ViewAppearing()
        {
            base.ViewAppearing();
            await _navigationService.Navigate<MenuViewModel>();
            await _navigationService.Navigate<HomeViewModel>();
        }
        public IMvxCommand CartPage
        {
            get
            {
                return new MvxCommand(async () => await _navigationService.Navigate<CartViewModel>());
            }
        }
    }
}
