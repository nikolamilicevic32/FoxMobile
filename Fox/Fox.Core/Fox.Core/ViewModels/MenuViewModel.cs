using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Fox.Core.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private ObservableCollection<string> _menuItemList;
        private IMvxAsyncCommand<string> _showDetailPageAsyncCommand;


        public MenuViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            MenuItemList = new MvxObservableCollection<string>()
            {
                "Katalog proizvoda",
                "Korpa",
                "Kontakt"
            };
        }

        #region MenuItemList;
        public ObservableCollection<string> MenuItemList
        {
            get => _menuItemList;
            set => SetProperty(ref _menuItemList, value);
        }
        #endregion

        #region Commands;
        public IMvxAsyncCommand<string> ShowDetailPageAsyncCommand
        {
            get
            {
                _showDetailPageAsyncCommand = _showDetailPageAsyncCommand ?? new MvxAsyncCommand<string>(ShowDetailPageAsync);
                return _showDetailPageAsyncCommand;
            }
        }
        #endregion

        #region Private methods
        private async Task ShowDetailPageAsync(string param)
        {
            switch (param)
            {
                case "Katalog proizvoda":
                    await _navigationService.Navigate<HomeViewModel>();
                    break;
                case "Korpa":
                    await _navigationService.Navigate<CartViewModel>();
                    break;
                case "Kontakt":
                    await _navigationService.Navigate<ContactsViewModel>();
                    break;
                default:
                    break;
            }

            if (Application.Current.MainPage is MasterDetailPage masterDetailPage)
            {
                masterDetailPage.IsPresented = false;
            }

            if (Application.Current.MainPage is NavigationPage navigationPage &&
                navigationPage.CurrentPage is MasterDetailPage nestedMasterDetail)
            {
                nestedMasterDetail.IsPresented = false;
            }
        }
        #endregion
    }
}
