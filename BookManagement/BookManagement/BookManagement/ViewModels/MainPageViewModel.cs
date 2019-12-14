using BookManagement.Objects;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookManagement.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        /*ここから*/
        private List<Cat> _Cats;
        public List<Cat> Cats
        {
            get { return _Cats; }
            set { SetProperty(ref _Cats, value); }
        }
        /*ここまで*/
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Book Mnagement";

            /*ここから最後まで*/
            Cats = new List<Cat>
            {
                new Cat { Name = "A", Comment = "a", Image = "bookImage.jpg" },
                new Cat { Name = "B", Comment = "b", Image = "bookImage.jpg" },
                new Cat { Name = "C", Comment = "c", Image = "bookImage.jpg" },
                new Cat { Name = "D", Comment = "d", Image = "bookImage.jpg" },
                new Cat { Name = "E", Comment = "e", Image = "bookImage.jpg" },
                new Cat { Name = "F", Comment = "f", Image = "bookImage.jpg" },
                new Cat { Name = "G", Comment = "g", Image = "" },
                new Cat { Name = "H", Comment = "h", Image = "" }
            };



            RegisteredBooks();

            SaveButton_Clicked = new DelegateCommand(() => SaveButton_Click());
            ReadButton_Clicked = new DelegateCommand(() => RegisteredBooks());
            BookDetails_Clicked = new DelegateCommand(() => navigationService.NavigateAsync("BookDetailsPage"));

        }   



        //ListView表示用の猫のクラス
        public class Cat
        {
            public string Name { get; set; }
            public string Comment { get; set; }
            public string Image { get; set; }
        }




        public DelegateCommand SaveButton_Clicked { get; private set; }

        //名前
        private string _NameEntry;
        public string NameEntry
        {
            get { return _NameEntry; }
            set { SetProperty(ref _NameEntry, value); }
        }

        //電話番号
        private string _PhoneEntry;
        public string PhoneEntry
        {
            get { return _PhoneEntry; }
            set { SetProperty(ref _PhoneEntry, value); }
        }

        //表示する
        private string _RegisteredBooksData;
        public string RegisteredBooksData
        {
            get { return _RegisteredBooksData; }
            set { SetProperty(ref _RegisteredBooksData, value); }
        }

        //本名
        private string _BooksName;
        public string BooksName
        {
            get { return _BooksName; }
            set { SetProperty(ref _BooksName, value); }
        }

        //本名
        private string _ImageUrl;
        public string ImageUrl
        {
            get { return _ImageUrl; }
            set { SetProperty(ref _ImageUrl, value); }
        }





        public DelegateCommand ReadButton_Clicked { get; private set; }
        public DelegateCommand BookDetails_Clicked { get; private set; }


        //保存ボタンがクリックされたらCustomerの名前を電話番号にデータを保存する
        private void SaveButton_Click()
        {
            var customer = new Customer()
            {
                Name = NameEntry,
                Phone = PhoneEntry,
            };

            ////SQLiteデータベースの指定
            //string databaseName = "Shop,db";
            //string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //string databasePath = System.IO.Path.Combine(folderPath, databaseName);

            //SQLiteと接続
            //初回は空のテーブルを作成。次回から該当DBに接続
            using (var connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Customer>();
                connection.Insert(customer);
            }
        }

        ////Readボタンが押されたらデータベースの内容を読み込む
        //private void ReadButton_Click()
        //{
        //    using (var connection = new SQLiteConnection(App.DatabasePath))
        //    {
        //        connection.CreateTable<Customer>();
        //        var customers = connection.Table<Customer>().ToList();
        //        Console.WriteLine(customers[0].Name);

        //    }
        //}

        //DBの内容を読み込む
        private void RegisteredBooks()
        {
            using (var connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Customer>();
                var customers = connection.Table<Customer>().ToList();
                Console.WriteLine(customers[0].Name);
                foreach (var customer in customers)
                {
                    RegisteredBooksData += customer.Id;
                    RegisteredBooksData += customer.Name;
                    RegisteredBooksData += customer.Phone;
                    RegisteredBooksData += customer.title;
                    RegisteredBooksData += customer.imageUrl;


                }
                BooksName = customers[0].title;
                ImageUrl = customers[0].imageUrl;
            }
        }
    }
}
