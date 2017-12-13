using System;
using System.Threading.Tasks;
using Refit;

namespace LuckyBeer
{
    public interface IBeerService
    {
        [Get("/beer/random")]
        Task<Beer> Random();
    }
}
