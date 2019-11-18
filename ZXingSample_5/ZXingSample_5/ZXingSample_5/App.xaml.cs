using Prism;
using Prism.Ioc;
using ZXingSample_5.ViewModels;
using ZXingSample_5.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ZXingSample_5
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        /*
         * Visual StudioのXamarin Forms XAMLプレビューアはSystem.Activator.CreateInstanceを使用します。
         * これにより、Appクラスにデフォルトコンストラクターが必要になるという制限が課せられます。
         * App（IPlatformInitializer initializer = null）は、Activatorで処理できません。
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            ////ここを変更
            //MainPage = new NavigationPage(new MainPage());

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<PrismContentPage1, PrismContentPage1ViewModel>();
            containerRegistry.RegisterForNavigation<QRScanPage, QRScanPageViewModel>();

        }
    }
}
