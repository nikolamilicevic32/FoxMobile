using Fox.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fox.Core.Views
{
   // [XamlCompilation(XamlCompilationOptions.Compile)]
   // [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail, NoHistory = true, Title = "Item Page")]
    public partial class ItemPage : MvxContentPage<ItemViewModel>
    {        
        public ItemPage()
        {
            InitializeComponent();
        }
    }
}
