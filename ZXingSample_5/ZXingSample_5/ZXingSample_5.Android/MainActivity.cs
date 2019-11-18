using Android.App;
using Android.Content.PM;
using Android.OS;
using Prism;
using Prism.Ioc;

namespace ZXingSample_5.Droid
{
    [Activity(Label = "ZXingSample_5", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
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

            LoadApplication(new App(new AndroidInitializer()));
        }
    }


    //追加
    //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
    //{
    //    global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    //}

    //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
    //{
    //    global::ZXing.Net.Mobile.Forms.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    //}
    public class AndroidInitializer : IPlatformInitializer
    {

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
            // (プラットフォーム固有の実装を登録する)
        }
    }
}

