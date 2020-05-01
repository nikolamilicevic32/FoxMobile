using Fox.Common.Models;
using Fox.Core.Services;
using Fox.DataProvider;
using Fox.DataProvider.InterfaceServices;
using Fox.Presentation.Abstraction;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Fox.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        #region Private fields
        private Category _selectedCategory;
        private event EventHandler _eventHandler;

        private readonly IMvxNavigationService _navigationService;
        private readonly IItemPresnetation _itemPresentation;
        private readonly ICategoryPresentation _categoryPresentation;
        #endregion

        #region Public fields
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Item> Items { get; set; }
        public Item SelectedItem { get; set; }
        #endregion

        #region Constructor
        public HomeViewModel(IItemPresnetation itemPresnetation, ICategoryPresentation categoryPresentation, IMvxNavigationService navigationService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _itemPresentation = itemPresnetation ?? throw new ArgumentNullException(nameof(itemPresnetation));
            _categoryPresentation = categoryPresentation ?? throw new ArgumentNullException(nameof(categoryPresentation));

            _eventHandler += ChangeCategory__eventHandler;
        }
        #endregion

        #region Public properties
        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                if (_selectedCategory != null)
                {
                    _eventHandler.Invoke(this, EventArgs.Empty);
                }
            }
        }
        #endregion

        #region Public methods
        public override async Task Initialize()
        {
            await base.Initialize();
            await PopulateDataAction();
        }
        #endregion

        #region Commands
        /// <summary>
        /// Detail item command
        /// </summary>
        public IMvxCommand DetailItem
        {
            get
            {
                return new MvxCommand(async () => await DetailItemAction(SelectedItem));
            }
        }

        /// <summary>
        /// Change category command
        /// </summary>
        public IMvxCommand ChangeCategory
        {
            get
            {
                return new MvxCommand(async () => await PopulateDataAction());
            }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Event that raise when category is changed and invoke new items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ChangeCategory__eventHandler(object sender, EventArgs e)
        {
            await PopulateDataAction();
        }

        /// <summary>
        /// Method that return items and categories
        /// </summary>
        /// <returns></returns>
        private async Task PopulateDataAction()
        {
            await _itemPresentation.GetLatestItemsFromApi();
            await _categoryPresentation.GetLatestCategoriesFromApi();
            Categories = await _categoryPresentation.GetCategories().ConfigureAwait(false);
            Items = await _itemPresentation.GetItems(SelectedCategory).ConfigureAwait(false);

            await RaiseAllPropertiesChanged();
        }

        /// <summary>
        /// Method that navigate to specific item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private async Task DetailItemAction(Item item)
        {
            await _navigationService.Navigate<ItemViewModel, Item>(item);
        }
        #endregion
    }
}
