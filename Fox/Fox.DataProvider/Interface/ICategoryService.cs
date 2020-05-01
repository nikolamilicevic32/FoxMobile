using Fox.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fox.DataProvider
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoryAsync();
    }
}
