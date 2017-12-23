using System;
using System.Windows.Input;
using Prism.Mvvm;
using Prism.Commands;
using System.Threading.Tasks;

namespace LuckyBeer
{
    public class LuckuBeerViewModel : BindableBase
    {
        public ICommand GetRundomCommand { get; }
        Beer _currentBeer;

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
            var response = await _service.Random();
            CurrentBeer = response.Data;
        }

        private readonly IBeerService _service;
    }
}
