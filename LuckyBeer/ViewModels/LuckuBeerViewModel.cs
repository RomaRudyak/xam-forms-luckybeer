using System;
using System.Windows.Input;
using Prism.Mvvm;
using Prism.Commands;
using System.Threading.Tasks;

namespace LuckyBeer
{
    public class LuckuBeerViewModel : BindableBase
    {
        public enum ModelState
        {
            Default,
            Loading,
            Details,
            PoweredBy
        }

        private ModelState _state;
        public ModelState State
        {
            get => _state;
            set => SetProperty(ref _state, value);
        }

        public async Task OnAppearing()
        {
            State = ModelState.PoweredBy;
            await Task.Delay(2000);
            State = ModelState.Default;
        }

        public ICommand GetRundomCommand { get; }

        private Beer _currentBeer;
        public Beer CurrentBeer
        {
            get => _currentBeer;
            set => SetProperty(ref _currentBeer, value);
        }

        public LuckuBeerViewModel(IBeerService service)
        {
            _service = service;

            GetRundomCommand = new DelegateCommand(async () => await GetRandom());
        }

        private async Task GetRandom()
        {
            State = ModelState.Loading;

            var response = await _service.Random();
            CurrentBeer = response.Data;

            State = ModelState.Details;
        }

        private readonly IBeerService _service;
    }
}
