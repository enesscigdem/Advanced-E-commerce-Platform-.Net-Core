using System.Text.Json;

namespace StoreApp.Infrastructre.Extensions
{
    // Extensions ifadeleri genellikle static classlara, ifadelere yazılır.
    // Statik bir class'ın bütün üyeleri static olur ve new'leme yapmadan erişebiliriz.
    public static class SessionExtension
    {
        //objeye bağlı çalışıyor
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        //tipe bağlı çalışıyor <Generic>
        public static void SetJson<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        public static T? GetJson<T>(this ISession session, string key)
        {
            var data = session.GetString(key);
            return data is null
            ? default(T)
            : JsonSerializer.Deserialize<T>(data);
        }
    }
}