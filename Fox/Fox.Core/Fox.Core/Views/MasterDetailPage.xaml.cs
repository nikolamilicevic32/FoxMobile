using Fox.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using System.Drawing;
using Xamarin.Forms.Xaml;

namespace Fox.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Root, WrapInNavigationPage = false, Title = "MasterDetail Page")]
    public partial class MasterDetailPage : MvxMasterDetailPage<MasterDetailViewModel>
    {
        public MasterDetailPage()
        {
            InitializeComponent();
            this.BackgroundColor = Color.Black;
            
        }

    }
}