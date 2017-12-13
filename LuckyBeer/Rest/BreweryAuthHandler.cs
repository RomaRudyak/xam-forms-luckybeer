using System;
using System.Net.Http;
using System.Web;
namespace LuckyBeer
{
    public class BreweryAuthHandler : DelegatingHandler
    {
        private readonly string _key;

        public BreweryAuthHandler(HttpMessageHandler innerHandler, string key)
            : base(innerHandler)
            => _key = key;

        protected override async System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var b = new UriBuilder(request.RequestUri);
            var q = HttpUtility.ParseQueryString(b.Query);
            q["key"] = _key;
            b.Query = q.ToString();
            request.RequestUri = b.Uri;
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
