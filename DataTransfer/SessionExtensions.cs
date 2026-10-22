using System.Text.Json;

namespace DataTransfer;

public static class SessionExtensions
{

    public static void SetObject<T>(this ISession session, string key, T value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }

    public static T GetObject<T>(this ISession session, string key)
    {
        var valueJson = session.GetString(key);
        if (!string.IsNullOrEmpty(valueJson))
        {
            return JsonSerializer.Deserialize<T>(valueJson);
        }

        return default(T);
    }
    
}