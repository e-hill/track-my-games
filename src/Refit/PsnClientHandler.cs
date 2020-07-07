using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Http.Logging;

namespace TrackMyGames.Refit
{
    public class PsnClientHandler : HttpClientHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Headers.Contains("Meta-Cookie"))
            {
                var baseUrl = $"{request.RequestUri.Scheme}://{request.RequestUri.Host}";
                var cookies = request.Headers.GetValues("Meta-Cookie");

                CookieContainer.SetCookies(new Uri(baseUrl), string.Join(";", cookies));
                request.Headers.Remove("Meta-Cookie");
            }

            // See if the request has an authorize header
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}