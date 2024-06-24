namespace Contracts.DataTransferObjects
{
    public record InstrumentPairDto : BaseDto
    {
        public long Id { get; init; }
        public string? Pair { get; init; }
        public string? Description { get; init; }
        public string? BaseCurrency { get; init; }
        public string? NonBaseCurrency { get; init; }
        public string? QuotesPair { get; init; }
        public string? ImagePath { get; init; }
    }
}
