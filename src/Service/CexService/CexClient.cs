using System.Net.Http.Headers;

namespace CexService
{
    public class CexClient : HttpClient
    {
        private static readonly Lazy<CexClient> _instance = new Lazy<CexClient>(() => new CexClient());

        public static CexClient Instance => _instance.Value;

        public string? Token { get; set; }

        private CexClient()
        {
            BaseAddress = new Uri("https://cex.io/api/");
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// The public APIs do not require authentication.
        /// </summary>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetPublicAsync(string requestUri)
        {
            return await GetAsync(GetRequestUrl(requestUri));
        }

        /// <summary>
        /// The Http handler is not using the base address always depending on the requestUri, so we need to add it manually.
        /// </summary>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        private string GetRequestUrl(string requestUri)
        {
            return $"{BaseAddress?.AbsoluteUri.TrimEnd('/')}/{requestUri.TrimStart('/')}";
        }
    }
}
