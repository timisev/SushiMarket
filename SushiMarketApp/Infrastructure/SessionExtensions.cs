using Newtonsoft.Json;
using System.Text;

namespace SushiMarketApp.Infrastructure
{
    public static class SessionExtensions
    {
        static StringBuilder sb = new StringBuilder();
        static StringWriter sw = new StringWriter(sb);

        public static void SetJson(this ISession session, string key, object value)
        {
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                session.SetString(key, JsonConvert.SerializeObject(value));
            }
        }

        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);
        } 
    }
}
