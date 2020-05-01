using Fox.Common.Models;
using Fox.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fox.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail, NoHistory = true, Title = "")]
    public partial class HomeView : MvxContentPage<HomeViewModel>
    {
        private HomeViewModel _context;
        public HomeView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            _context = this.BindingContext.DataContext as HomeViewModel;
        }

        private void DetailItemEvent(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (Item)((CollectionView)sender).SelectedItem;
            if(item != null)
            {
                _context.SelectedItem = item;
                _context.DetailItem.Execute();
                ((CollectionView)sender).SelectedItem = null;
            }
        }

    }
}