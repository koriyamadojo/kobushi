using Codeplex.Data;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;


namespace BookManagement.ViewModels
{
    public class ScanPageViewModel : INotifyPropertyChanged
    {
       
        public event PropertyChangedEventHandler PropertyChanged;
        public ScanPageViewModel()
        {
            ScanButtonClicked = new Command<ZXing.Result>((result) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    this.IsAnalyzing = false;  //読み取り停止
                    string scannedCode = result.Text;

                    //ISBNコードだった
                    if (scannedCode.IndexOf("978") == 0)
                    {
                        
                        //DynamicJson bookData = RakutenAPI(scannedCode);
                        //Console.WriteLine(bookData);
                        //Console.WriteLine(bookData.GetType().FullName);
                        //string title = bookData.title;

                        string str = RakutenAPI(scannedCode);
                        Console.WriteLine(str);
                        var jsonData = DynamicJson.Parse(str); //先にNuGetを利用してDynamicJsonを導入している必要がある
                        Console.WriteLine(jsonData.count);

                        if (jsonData.count != 0)
                        {
                            SuccessFrameVisible = true; //SuccessFrameを表示
                            ScannedCode = result.Text;

                            var bookData = jsonData.Items[0].Item;
                            Console.WriteLine(bookData);
                            Console.WriteLine(bookData.GetType().FullName);
                            Console.WriteLine(bookData.title);
                            Console.WriteLine(bookData.largeImageUrl);
                            string imageUrl = bookData.largeImageUrl.Replace("?_ex=200x200", "");
                            Console.WriteLine(imageUrl);
                            ScannedMessage = bookData.title;
                            ScannedImage = imageUrl;

                            await Task.Delay(2000);    //1秒待機
                            SuccessFrameVisible = false;      //Frameを非表示
                            this.IsAnalyzing = true;   //読み取り再開

                        }
                        else
                        {
                            FailureFrameVisible = true; //FailureFrameを表示
                            ScannedMessage = "検索できませんでした";
                            await Task.Delay(2000);    //1秒待機
                            FailureFrameVisible = false;      //Frameを非表示
                            this.IsAnalyzing = true;   //読み取り再開
                        }
                    }
                    //ISBNコードじゃなかった
                    else
                    {
                        FailureFrameVisible = true; //FailureFrameを表示
                        ScannedMessage = "これは価格のバーコードです。\n上段のバーコードをスキャンしてください。";
                        await Task.Delay(2000);    //1秒待機
                        FailureFrameVisible = false;      //Frameを非表示
                        this.IsAnalyzing = true;   //読み取り再開

                        //await Task.Delay(1000);    //1秒待機
                        //this.IsAnalyzing = true;   //読み取り再開

                    }
                    
                    

                });
            });
        }
        public Command ScanButtonClicked { get; }


        private bool isAnalyzing;
        public bool IsAnalyzing
        {
            get { return isAnalyzing; }
            set
            {
                if (isAnalyzing != value)
                {
                    isAnalyzing = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAnalyzing)));
                }
            }
        }
        private string scannedImage;
        public string ScannedImage
        {
            get { return scannedImage; }
            set
            {
                if (scannedImage != value)
                {
                    scannedImage = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ScannedImage)));
                }
            }
        }
        private string scannedMessage;
        public string ScannedMessage
        {
            get { return scannedMessage; }
            set
            {
                if (scannedMessage != value)
                {
                    scannedMessage = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ScannedMessage)));
                }
            }
        }
        private string scannedCode;
        public string ScannedCode
        {
            get { return scannedCode; }
            set
            {
                if (scannedCode != value)
                {
                    scannedCode = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ScannedCode)));
                }
            }
        }
        private bool successFrameVisible;
        public bool SuccessFrameVisible
        {
            get { return successFrameVisible; }
            set
            {
                if (successFrameVisible != value)
                {
                    successFrameVisible = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SuccessFrameVisible)));
                }
            }
        }
        private bool failureFrameVisible;
        public bool FailureFrameVisible
        {
            get { return failureFrameVisible; }
            set
            {
                if (failureFrameVisible != value)
                {
                    failureFrameVisible = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FailureFrameVisible)));
                }
            }
        }




        /// <summary>
        /// 読み取ったISBNコードをもとに楽天APIから書籍を検索する
        /// </summary>
        public string RakutenAPI(string ScannedCode)
        {
            const string REQUEST_URL = "https://app.rakuten.co.jp/services/api/BooksBook/Search/20170404?";
            const string APPLICATION_ID = "1013677670082002246"; //ここにアプリIDを指定
            string isbn = ScannedCode; //ISBNコード
            string requstUrl = 
                REQUEST_URL
                + "format=json" //フォーマットの指定
                + "&isbn=" + isbn
                //+ "&isbn=9784813282983"
                + "&applicationId=" + APPLICATION_ID;

            //var testReq = await API();

            //リクエスト
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(requstUrl);
            req.Method = "GET"; //メソッドの形式
            HttpWebResponse res = (HttpWebResponse)req.GetResponse(); //リクエストして格納
            Console.WriteLine(res);

            //レスポンスデータ整形
            Stream s = res.GetResponseStream(); //レスポンスのストリームを取得
            StreamReader sr = new StreamReader(s);
            string str = sr.ReadToEnd(); //ストリームの内容を全てstrに格納

            //var jsonData = DynamicJson.Parse(str); //先にNuGetを利用してDynamicJsonを導入している必要がある
            //var bookData = jsonData.Items[0].Item;
            //Console.WriteLine(bookData);
            //Console.WriteLine(bookData.GetType().FullName);
            return (str);
        }


        //public async Task<string> API()
        //{

        //}




        public DelegateCommand AddButtonClicked { get; private set; }
        public DelegateCommand CancelButtonClicked { get; private set; }

        /// <summary>
        /// ISBNコード読み込んだときのボタン
        /// </summary>
        public ScanPageViewModel(INavigationService navigationService)
        {
            AddButtonClicked = new DelegateCommand(
                () =>
                {
                    SuccessFrameVisible = false;      //Frameを非表示
                    this.IsAnalyzing = true;   //読み取り再開
                }, // 実行される内容
                () => true); // 実行できるか？

            CancelButtonClicked = new DelegateCommand(
                () =>
                {
                    SuccessFrameVisible = false;      //Frameを非表示
                    this.IsAnalyzing = true;   //読み取り再開
                }, // 実行される内容
                () => true); // 実行できるか？

        }

    }

}
