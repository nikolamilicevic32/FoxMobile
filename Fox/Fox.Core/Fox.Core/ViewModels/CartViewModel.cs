using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Fox.Common.Models;
using Fox.Presentation.Abstraction;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Fox.Core.ViewModels
{
    public class CartViewModel : MvxViewModel
    {
        private double _totalSum;

        public double TotalSum
        {
            get { return _totalSum; }
            set
            {
                _totalSum = value;
                RaisePropertyChanged();
            }
        }
        private readonly IMvxNavigationService _navigationService;
        private readonly ICartItemPresentation _cartItemPresentation;

        public ObservableCollection<CartItem> CartItems { get; set; }
        
        public CartViewModel(ICartItemPresentation cartItemPresentation, IMvxNavigationService navigationService)
        {
            _cartItemPresentation = cartItemPresentation ?? throw new ArgumentNullException(nameof(cartItemPresentation));
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
        }

        public async override Task Initialize()
        {
            await base.Initialize();
            await PopulateData();
        }

        private async Task PopulateData()
        {
            CartItems = await _cartItemPresentation.GetAll().ConfigureAwait(false);
            CartItems.ToList().ForEach(x => TotalSum += x.Price);
            await RaiseAllPropertiesChanged();
        }

        public IMvxCommand RemoveFromCart
        {
            get
            {
                return new MvxCommand<Guid>(async id => await RemoveItemAction(id));                
            }
        }

        public IMvxCommand NextPage
        {
            get
            {
                return new MvxCommand(async () => await ShipingDetailPage());
            }
        }

        public IMvxCommand ClearCommand
        {
            get
            {
                return new MvxCommand(async () => await ClearCartAction());
            }
        }

        private async Task ShipingDetailPage()
        {
            await _navigationService.Navigate<ShipingDetailViewModel>(); 
        }

        private async Task RemoveItemAction(Guid id)
        {
            var item = CartItems.FirstOrDefault(x => x.Id.Equals(id));
            if(item != null)
            {
                await _cartItemPresentation.Remove(item);
                CartItems.Remove(item);
                TotalSum -= item.Price;
            }
        }

        private async Task ClearCartAction()
        {
            await _cartItemPresentation.RemoveAll();
            CartItems.Clear();
            TotalSum = 0;
        }
    }
}
