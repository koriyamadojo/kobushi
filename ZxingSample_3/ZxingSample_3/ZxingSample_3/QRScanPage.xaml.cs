using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZxingSample_3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRScanPage : ContentPage
    {
        public QRScanPage()
        {
            InitializeComponent();
        }

        void Handle_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                zxing.IsAnalyzing = false;  //読み取り停止
                await DisplayAlert("通知", "次の値を読み取りました：" + result.Text, "OK");
                zxing.IsAnalyzing = true;   //読み取り再開
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            zxing.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            zxing.IsScanning = false;
            base.OnDisappearing();
        }


    }
}