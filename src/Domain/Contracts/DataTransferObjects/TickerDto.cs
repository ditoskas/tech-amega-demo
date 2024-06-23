namespace Contracts.DataTransferObjects
{
    public class TickerDto
    {
        public string? Timestamp { get; set; }

        public string? Low { get; set; }

        public string? High { get; set; }

        public string? LastPrice { get; set; }

        public string? Volume { get; set; }

        public string? VolumeMonthly { get; set; }

        public decimal Bid { get; set; }

        public decimal Ask { get; set; }

        public string? PriceChange { get; set; }

        public string? PriceChangePercentagePercentage { get; set; }

        public string? Pair { get; set; }
    }
}
