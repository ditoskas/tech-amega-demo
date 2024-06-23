using CexService.Responses;
using Shared.Utilities;

namespace CexService
{
    public static class CexRequestor
    {
        /// <summary>
        /// Get the last price of a currency pair.
        /// </summary>
        /// <param name="pair">Pair separated by a hyphen</param>
        /// <returns>
        /// {
        /// "lprice": "17663",
        /// "curr1": "BTC",
        /// "curr2": "USD"
        /// }
        /// </returns>
        /// <exception cref="ArgumentException"></exception>
        public static async Task<LastPriceResponse?> GetLastPrice(string pair)
        {
            string[] currencies = ValidatePairAndGetCurrencies(pair);

            HttpResponseMessage response = await CexClient.Instance.GetPublicAsync($"last_price/{currencies[0]}/{currencies[1]}");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            
            return Serializer.Deserialize<LastPriceResponse>(content);
        }

        /// <summary>
        /// Get the last price of a currency pair.
        /// </summary>
        /// <param name="pair">Pair separated by a hyphen</param>
        /// <returns>
        /// {
        /// "lprice": "17663",
        /// "curr1": "BTC",
        /// "curr2": "USD"
        /// }
        /// </returns>
        /// <exception cref="ArgumentException"></exception>
        public static async Task<TickerResponse?> GetTicker(string pair)
        {
            string[] currencies = ValidatePairAndGetCurrencies(pair);

            HttpResponseMessage response = await CexClient.Instance.GetPublicAsync($"ticker/{currencies[0]}/{currencies[1]}");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();

            return Serializer.Deserialize<TickerResponse>(content);
        }

        /// <summary>
        /// If it is a valid pair, it splits the pair and returns the two currencies.
        /// </summary>
        /// <param name="pair">Pair separated by a hyphen</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string[] ValidatePairAndGetCurrencies(string pair)
        {
            if (string.IsNullOrWhiteSpace(pair))
            {
                throw new ArgumentException("Pair cannot be null or empty.", nameof(pair));
            }
            string[] currencies = pair.Split('-');

            if (currencies.Length != 2)
            {
                throw new ArgumentException("Pair must contain two currencies separated by a hyphen.", nameof(pair));
            }
            return currencies;
        }
    }
}
