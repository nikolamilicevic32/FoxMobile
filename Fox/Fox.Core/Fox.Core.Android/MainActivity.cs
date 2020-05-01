using Android.App;
using Android.Content.PM;
using Android.OS;
using CarouselView.FormsPlugin.Android;
using FFImageLoading.Forms.Platform;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Forms.Platforms.Android.Views;

namespace Fox.Core.Droid
{
    [Activity(
        Label = "Fox.Core.Android",
        Icon = "@drawable/xamarin_logo",
        Theme = "@style/MainTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        LaunchMode = LaunchMode.SingleTask)]
    public class MainActivity : MvxFormsAppCompatActivity<MvxFormsAndroidSetup<Core, App>, Core, App>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {           
            global::Xamarin.Forms.Forms.SetFlags(new[] { "CollectionView_Experimental" });
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
            InitControls();
            
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            CachedImageRenderer.Init(enableFastRenderer: true);
            CachedImageRenderer.InitImageViewHandler();           
        }
       private void InitControls()
        {
            CarouselViewRenderer.Init();
        }
    }
}