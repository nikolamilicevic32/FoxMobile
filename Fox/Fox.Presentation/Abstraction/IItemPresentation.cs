using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Fox.Common.Models;

namespace Fox.Presentation.Abstraction
{
    public interface IItemPresnetation
    {
        Task<ObservableCollection<Item>> GetItems(Category category);
        Task GetLatestItemsFromApi();
    }
}
