using BookManagement.Objects;
using Prism.Commands;
using Prism.Mvvm;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookManagement.ViewModels
{
    public class BookDetailsPageViewModel : BindableBase
    {
        public BookDetailsPageViewModel()
        {
            RegisteredBooks();
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
                    RegisteredBooksData += "ID : ";
                    RegisteredBooksData += customer.Id;
                    //RegisteredBooksData += customer.Name;
                    //RegisteredBooksData += customer.Phone;
                    RegisteredBooksData += "タイトル : ";
                    RegisteredBooksData += customer.title;
                    RegisteredBooksData += "イメージURL : ";
                    RegisteredBooksData += customer.imageUrl;


                }
                BooksName = customers[0].title;
                ImageUrl = customers[0].imageUrl;
            }
        }
    }
}
