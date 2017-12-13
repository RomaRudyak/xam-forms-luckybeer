using Xamarin.Forms;

namespace LuckyBeer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LuckyBeerPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
