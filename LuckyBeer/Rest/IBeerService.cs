using System;
using System.Threading.Tasks;
using Refit;
using System.Net.Http;

namespace LuckyBeer
{
    public interface IBeerService
    {
        [Get("/beer/random")]
        Task<RandomResponse> Random();
    }
}
