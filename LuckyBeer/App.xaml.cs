﻿using Prism.Autofac;
using Xamarin.Forms;
using Prism;
using System;
using Prism.Ioc;
using Autofac;
using System.Net.Http;
using Refit;
using System.Reflection;

using LuckyBeer.Views;

namespace LuckyBeer
{
    public partial class App : PrismApplication
    {
        private const string ApiKey = "{API_KEY}";
        private const string ApiHost = "http://api.brewerydb.com/v2/";


        public App(IPlatformInitializer initializer = null)
            : base(initializer)
        {
            InitializeComponent();
        }

        protected override async void OnInitialized()
        {
            await NavigationService.NavigateAsync($"/Nav/{nameof(LuckyBeerPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var autofacContainer = containerRegistry.GetBuilder();
            RegisterRest(autofacContainer);
            RegistreVies(containerRegistry);
        }

        private void RegistreVies(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LuckyBeerPage, LuckuBeerViewModel>(nameof(LuckyBeerPage));
            containerRegistry.RegisterForNavigation<NavigationPage>("Nav");
        }

        private static void RegisterRest(ContainerBuilder autofacContainer)
        {
            autofacContainer
                .Register(c =>
                {
                    var hadler = new BreweryAuthHandler(new HttpClientHandler(), ApiKey);
                    return new HttpClient(hadler)
                    {
                        BaseAddress = new Uri(ApiHost)
                    };
                })
                .SingleInstance();

            autofacContainer.Register(
                c => RestService.For<IBeerService>(c.Resolve<HttpClient>()));
        }
    }
}