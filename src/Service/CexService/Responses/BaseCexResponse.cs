using System.Runtime.Serialization;

namespace CexService.Responses
{
    [DataContract]
    public class BaseCexResponse : ICexResponse
    {
        [DataMember(Name = "error")]

        public string? Error { get; set; }
    }
}
