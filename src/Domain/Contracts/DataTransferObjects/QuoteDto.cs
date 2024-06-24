namespace Contracts.DataTransferObjects
{
    public record QuoteDto(string symbol, string ts, decimal bid, decimal ask, decimal mid);
}