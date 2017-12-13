using Prism.Autofac;
using Xamarin.Forms;
using Prism;
using System;
using Prism.Ioc;

namespace LuckyBeer
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null)
            : base(initializer)
        {
            InitializeComponent();

            MainPage = new LuckyBeerPage();
        }

        protected override void OnInitialized()
        {

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
