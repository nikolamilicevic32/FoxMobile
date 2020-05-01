using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Fox.Common.Models;

namespace Fox.Presentation.Abstraction
{
    public interface ICategoryPresentation
    {
        Task<ObservableCollection<Category>> GetCategories();
        Task GetLatestCategoriesFromApi();
    }
}
