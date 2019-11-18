using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ZXingSample_5.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnQR(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QRScanPage());
        }
    }
}