using Newtonsoft.Json;

namespace Shared.Utilities
{
    public class Serializer
    {
        public static string Serialize<T>(T obj, JsonSerializerSettings? settings = null) => JsonConvert.SerializeObject(obj, settings);

        public static T? Deserialize<T>(string json, JsonSerializerSettings? settings = null) => JsonConvert.DeserializeObject<T>(json, settings);
        public static object? Deserialize(string json, Type? type, JsonSerializerSettings? settings = null) => JsonConvert.DeserializeObject(json, type, settings);
    }
}
