namespace Contracts.DataTransferObjects
{
    public record InstrumentPairDto : BaseDto
    {
        public long Id { get; init; }
        public string Pair { get; init; }
    }
}
