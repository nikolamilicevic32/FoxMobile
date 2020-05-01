using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Fox.Common.Models;

namespace Fox.Presentation.Abstraction
{
    public interface ICartItemPresentation
    {
        Task AddToCart(CartItem cartItem);
        Task<ObservableCollection<CartItem>> GetAll();
        Task Remove(CartItem cartItem);
        Task RemoveAll();
    }
}
