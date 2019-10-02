### **XAMARIN.FORMS**

- Instale o plugin do **Xamarin.Firebase.Ads** versão **60.1142.1**
- Duvidas de como criar um ID de Anuncio? [clique aqui](https://julianocustodio.com/2018/04/19/admob-xamarin-forms/)
- Duvidas sobre este passo a passo? [Whatsapp](https://wa.me/5579998682289)

No seu projeto Xamarin Forms, vamos criar uma classe chamada **AdMobView** 
dentro dela vamos adicionar o seguinte código:
```
public class AdMobView : View
	{
		public static readonly BindableProperty AdUnitIdProperty = BindableProperty.Create(
			nameof(AdUnitId),
			typeof(string),
			typeof(AdMobView),
			string.Empty);

		public string AdUnitId
		{
			get => (string)GetValue(AdUnitIdProperty);
			set => SetValue(AdUnitIdProperty, value);
		}
	}
```
feito isso vamos adicionar uma **interface** chamada  **IAdmobInterstitialAds** e adicionar o seguinte código:
```
 public interface IAdmobInterstitialAds
    {
        Task Display(string adId);
    }
```

vamos criar uma classe chamada **ID_ADS** que vai conter os ID dos anúncios:
```
 public class ID_ADS
    {
        public static string AppId
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        return "";
                    default:
                        return "";
                }
            }
        }

        public static string BannerId
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        return "ca-app-pub-3940256099942544/6300978111";
                    default:
                        return "ca-app-pub-3940256099942544/6300978111";
                }
            }
        }

        public static string InterstitialAdId
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        return "ca-app-pub-3940256099942544/1033173712";
                    default:
                        return "ca-app-pub-3940256099942544/1033173712";
                }
            }
        }

        public static bool ShowAds
        {
            get
            {
                _adCounter++;
                if (_adCounter % 5 == 0)
                {
                    return true;
                }
                return false;
            }
        }

        private static int _adCounter;

    } 
```
### **Xaml**
Em sua **MainPage.xaml**  adicione o seguinte código:
 ```
<StackLayout>

        <ads:AdMobView x:Name="adMobView" 
                         VerticalOptions="EndAndExpand"/>

        <Button Text="Show ITS ADS" Clicked="Button_Clicked"></Button>
    </StackLayout>
```
e no **MainPage.xaml.cs :** 
```
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
```

pronto agora vamos para o Projeto Android, na **MainActivity** vamos inicializar o plugin:
```
 protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);          
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            //inicialização do plugin 
             MobileAds.Initialize(ApplicationContext, "ca-app-pub-3940256099942544/6300978111");
          //Fim inicialização do plugin
   LoadApplication(new App());
        }
```

e por ultimo no **AndroidManifest** vamos adicionar os seguinte comandos:
```
<manifest xmlns:android="http://schemas.android.com/apk/res/android" android:versionCode="1" android:versionName="1.0" package="com.companyname.AdminHall">
    <uses-sdk android:minSdkVersion="21" android:targetSdkVersion="27" />
   //adicionando permissões
    <uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
	  <uses-permission android:name="android.permission.INTERNET" />
 <activity android:name="com.google.android.gms.ads.AdActivity" android:configChanges="keyboard|keyboardHidden|orientation|screenLayout|uiMode|screenSize|smallestScreenSize" android:theme="@android:style/Theme.Translucent" />
   //fim Permissões
</manifest>
```

pronto! agora basta testar!
