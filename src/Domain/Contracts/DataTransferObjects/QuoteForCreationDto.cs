namespace Contracts.DataTransferObjects
{
    public record QuoteForCreationDto(string symbol, DateTimeOffset ts, decimal bid, decimal ask, decimal mid);
}