using AdminHall.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AdminHall
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();           
            adMobView.AdUnitId = "ca-app-pub-3940256099942544/6300978111";
        }      

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (ID_ADS.ShowAds)
            {
                await DependencyService.Get<IAdmobInterstitialAds>().Display(ID_ADS.InterstitialAdId);
            }
           
        }
    }
}
