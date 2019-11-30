using Prism;
using Prism.Ioc;
using BookManagement.ViewModels;
using BookManagement.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BookManagement
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */

        //SQLiteで追加
        static string databaseName = "Shop.db";
        static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string DatabasePath = System.IO.Path.Combine(folderPath, databaseName);

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
            containerRegistry.RegisterForNavigation<ScanPage, ScanPageViewModel>();
        }
    }
}
