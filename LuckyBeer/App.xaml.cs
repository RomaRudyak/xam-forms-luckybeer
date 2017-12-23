using Prism.Autofac;
using Xamarin.Forms;
using Prism;
using System;
using Prism.Ioc;
using Autofac;
using System.Net.Http;
using Refit;
using System.Reflection;

namespace LuckyBeer
{
    public partial class App : PrismApplication
    {
        private const string ApiKey = "{API_KEY}";

        public App(IPlatformInitializer initializer = null)
            : base(initializer)
        {
            InitializeComponent();

            MainPage = new LuckyBeerPage();
        }

        protected override async void OnInitialized()
        {
            var t = await Container.Resolve<IBeerService>().Random();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var autofacContainer = containerRegistry.GetBuilder();

            autofacContainer
                .Register(c =>
                {
                    var hadler = new BreweryAuthHandler(new HttpClientHandler(), ApiKey);
                    return new HttpClient()
                    {
                        BaseAddress = new Uri("http://api.brewerydb.com/v2/")
                    };
                })
                .SingleInstance();

            autofacContainer.Register(
                c => RestService.For<IBeerService>(c.Resolve<HttpClient>()));
        }
    }
}