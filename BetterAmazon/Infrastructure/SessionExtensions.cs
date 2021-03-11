using System;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace BetterAmazon.Infrastructure
{
    //This extends the session to allow us to store data about books in Json files.
    public  static class SessionExtensions
    {
        public static void SetJson (this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T GetJson<T> (this ISession session, string key)
        {
            var sessionData = session.GetString(key);

            return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
