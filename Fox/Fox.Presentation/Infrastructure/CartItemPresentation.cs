using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AutoMapper;
using Fox.Common.Models;
using Fox.Presentation.Abstraction;
using Fox.Repository;
using Fox.Repository.Models;

namespace Fox.Presentation.Infrastructure
{
    public class CartItemPresentation : ICartItemPresentation
    {
        private readonly IGenericRepository<CartItemDto> _cartItemRepository;
        private readonly IMapper _mapper;

        public CartItemPresentation(IGenericRepository<CartItemDto> cartItemRepository, IMapper mapper)
        {
            _cartItemRepository = cartItemRepository ?? throw new ArgumentNullException(nameof(cartItemRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ObservableCollection<CartItem>> GetAll()
        {
            var items = await _cartItemRepository.GetAll();

            return _mapper.Map<IEnumerable<CartItemDto>, ObservableCollection<CartItem>>(items);
        }

        public async Task RemoveAll()
        {
            await _cartItemRepository.RemoveAll();
        }

        public async Task Remove(CartItem cartItem)
        {
            await _cartItemRepository.Remove(_mapper.Map<CartItem, CartItemDto>(cartItem));
        }

        public async Task AddToCart(CartItem cartItem)
        {
            await _cartItemRepository.Add(_mapper.Map<CartItem, CartItemDto>(cartItem));
        }
    }
}
