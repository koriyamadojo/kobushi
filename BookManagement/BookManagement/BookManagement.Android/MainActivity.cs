using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using Prism;
using Prism.Ioc;

namespace BookManagement.Droid
{
    //[Activity(Label = "BookManagement", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [Activity(Label = "BookManagement", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]

    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            //追加
            ZXing.Net.Mobile.Forms.Android.Platform.Init();
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(enableFastRenderer: true);

            LoadApplication(new App(new AndroidInitializer()));
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }

    //public override bool OnCreateOptionsMenu(IMenu menu)
    //{
    //    MenuInflater.Inflate(Resource.Menu.top_menus, menu);
    //    return base.OnCreateOptionsMenu(menu);
    //}
    //public override bool OnOptionsItemSelected(IMenuItem item)
    //{
    //    Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
    //        ToastLength.Short).Show();
    //    return base.OnOptionsItemSelected(item);
    //}
}

