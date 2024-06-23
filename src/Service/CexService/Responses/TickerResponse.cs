using System.Runtime.Serialization;

namespace CexService.Responses
{
    [DataContract]
    public class TickerResponse : BaseCexResponse
    {
        [DataMember(Name = "timestamp")]
        public string? Timestamp { get; set; }

        [DataMember(Name = "low")]
        public string? Low { get; set; }

        [DataMember(Name = "high")]
        public string? High { get; set; }

        [DataMember(Name = "last")]
        public string? LastPrice { get; set; }

        [DataMember(Name = "volume")]
        public string? Volume { get; set; }

        [DataMember(Name = "volume30d")]
        public string? VolumeMonthly { get; set; }

        [DataMember(Name = "bid")]
        public decimal Bid { get; set; }

        [DataMember(Name = "ask")]
        public decimal Ask { get; set; }

        [DataMember(Name = "priceChange")]
        public string? PriceChange { get; set; }

        [DataMember(Name = "priceChangePercentage")]
        public string? PriceChangePercentagePercentage{ get; set; }

        [DataMember(Name = "pair")]
        public string? Pair { get; set; }
    }
}
