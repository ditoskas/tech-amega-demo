using Newtonsoft.Json;

namespace Shared.Utilities
{
    public class Serializer
    {
        public static string Serialize<T>(T obj, JsonSerializerSettings? settings = null) => JsonConvert.SerializeObject(obj, settings);

        public static T? Deserialize<T>(string json, JsonSerializerSettings? settings = null) => JsonConvert.DeserializeObject<T>(json, settings);
    }
}
