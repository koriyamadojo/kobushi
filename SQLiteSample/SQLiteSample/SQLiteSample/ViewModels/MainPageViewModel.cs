using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SQLite;
using SQLiteSample.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLiteSample.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

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

        public DelegateCommand ReadButton_Clicked { get; private set; }


        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            SaveButton_Clicked = new DelegateCommand(() => SaveButton_Click());
            ReadButton_Clicked = new DelegateCommand(() => ReadButton_Click());
        }

        //保存ボタンがクリックされたらCustomerの名前を電話番号にデータを保存する
        private void SaveButton_Click()
        {
            var customer = new Customer()
            {
                Name = NameEntry,
                Phone = PhoneEntry,
            };

            //SQLiteデータベースの指定
            string databaseName = "Shop,db";
            string folderPath =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string databasePath = System.IO.Path.Combine(folderPath, databaseName);

            //SQLiteと接続
            //初回は空のテーブルを作成。次回から該当DBに接続
            using (var connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Customer>();
                connection.Insert(customer);
            }
        }

        //Readボタンが押されたらデータベースの内容を読み込む
        private void ReadButton_Click()
        {
            using (var connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Customer>();
                var customers = connection.Table<Customer>().ToList();
            }
        }


    }
}
