using Fox.Common.Models;
using Fox.DataProvider.InterfaceServices;
using Fox.Presentation.Abstraction;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Threading.Tasks;

namespace Fox.Core.ViewModels
{
    public class ItemViewModel : MvxViewModel<Item>
    {
        private readonly ICartItemPresentation _cartItemPresnetation;
        private readonly IMvxNavigationService _navigationService;

        public Item ItemModel { get; set; }

        public ItemViewModel(ICartItemPresentation cartItemPresentation, IMvxNavigationService navigationService)
        {
            _cartItemPresnetation = cartItemPresentation ?? throw new ArgumentNullException(nameof(cartItemPresentation));
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
        }


        public override async Task Initialize()
        {
            await base.Initialize();
        }
        public override void Prepare(Item parameter)
        {
            ItemModel = parameter;
            RaiseAllPropertiesChanged();
        }

        public IMvxCommand AddToCart
        {
            get
            {
                return new MvxCommand(async () => await AddToCartAction());
            }
        }

        public IMvxCommand Buy
        { 
            get
            {
                return new MvxCommand(async () => await BuyItemAction());
            }
        }

        private async Task BuyItemAction()
        {
            CartItem cartItem = new CartItem(ItemModel);
            await _cartItemPresnetation.AddToCart(cartItem);
            await _navigationService.Navigate<CartViewModel>();
        }

        private async Task AddToCartAction()
        {
            CartItem cartItem = new CartItem(ItemModel);
            await _cartItemPresnetation.AddToCart(cartItem);
        }
    }
}
