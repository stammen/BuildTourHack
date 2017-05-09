using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Knowzy.Common.Helpers
{
    public static class JsonHelper
    {
        static JsonHelper()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
            };
        }

        public static T Deserialize<T>(string serializedObject)
        {
            return string.IsNullOrWhiteSpace(serializedObject)
            ? default(T)
            : JsonConvert.DeserializeObject<T>(serializedObject, new StringEnumConverter());
        }
    }
}
