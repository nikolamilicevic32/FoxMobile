using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AutoMapper;
using Fox.Common.Models;
using Fox.DataProvider;
using Fox.Presentation.Abstraction;
using Fox.Repository;
using Fox.Repository.Models;

namespace Fox.Presentation.Infrastructure
{
    public class CategoryPresentation : ICategoryPresentation
    {
        private readonly ICategoryService _categoryService;
        private readonly IGenericRepository<CategoryDto> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryPresentation(ICategoryService categoryService, IGenericRepository<CategoryDto> categoryRepository, IMapper mapper)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        public async Task<ObservableCollection<Category>> GetCategories()
        {
            var categories = _mapper.Map<IEnumerable<CategoryDto>, ObservableCollection<Category>>
                (await _categoryRepository.GetAll());

            return categories;
        }

        /// <summary>
        /// Get latest categories from api and save in local db
        /// </summary>
        /// <returns></returns>
        public async Task GetLatestCategoriesFromApi()
        {
            var result = await _categoryService.GetCategoryAsync().ConfigureAwait(false);

            foreach(var category in result)
            {
                await _categoryRepository.Add(_mapper.Map<Category, CategoryDto>(category));
            }
        }
    }
}
