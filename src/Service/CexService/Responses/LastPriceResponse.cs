using System.Runtime.Serialization;

namespace CexService.Responses
{
    [DataContract]
    public class LastPriceResponse : BaseCexResponse
    {
        [DataMember(Name = "lprice")]

        public string? LastPrice { get; set; }

        [DataMember(Name = "curr1")]

        public string? BaseCurrency { get; set; }

        [DataMember(Name = "curr2")]

        public string? NonBaseCurrency { get; set; }

    }
}
