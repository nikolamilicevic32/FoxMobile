using Fox.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fox.DataProvider.InterfaceServices
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAllItems();
        Task<IEnumerable<Item>> GetItems(string categoryId);
        Task<Item> GetItem(Guid Id);
    }
}
