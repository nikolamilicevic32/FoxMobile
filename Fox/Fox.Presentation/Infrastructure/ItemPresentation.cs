using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AutoMapper;
using Fox.Common.Models;
using Fox.DataProvider.InterfaceServices;
using Fox.Presentation.Abstraction;
using Fox.Repository;
using Fox.Repository.Models;
using Fox.Presentation.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Fox.Presentation.Infrastructure
{
    public class ItemPresentation : IItemPresnetation
    {
        private readonly IItemService _itemService;
        private readonly IGenericRepository<ItemDto> _itemRepository;
        private readonly IMapper _mapper;

        public ItemPresentation(IItemService itemService, IGenericRepository<ItemDto> itemRepository, IMapper mapper)
        {
            _itemService = itemService ?? throw new ArgumentNullException(nameof(itemService));
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Get items based on category name
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<ObservableCollection<Item>> GetItems(Category category)
        {
            string categoryName = "featured";

            if (category != null)
            {
                categoryName = category.Name;
            }

            var items = _mapper.Map<IEnumerable<ItemDto>, ObservableCollection<Item>>
                ((await _itemRepository.GetAll().ConfigureAwait(false)));

            return items;
        }

        /// <summary>
        /// Get latest items from api and save in db
        /// </summary>
        /// <returns></returns>
        public async Task GetLatestItemsFromApi()
        {
            var items = await _itemService.GetItems("featured");

            foreach (var item in items)
            {
                    await _itemRepository.Add(_mapper.Map<Item, ItemDto>(item));
             }
        }
    }
}
