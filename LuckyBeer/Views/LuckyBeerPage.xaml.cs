using Xamarin.Forms;
using System.Threading.Tasks;

namespace LuckyBeer.Views
{
    public partial class LuckyBeerPage : ContentPage
    {
        public LuckyBeerPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var vm = (LuckuBeerViewModel)BindingContext;

            await vm.OnAppearing();


        }
    }
}
