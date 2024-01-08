using Newtonsoft.Json;

public class JsonConverter
{
    public static T? DeserializeResponse<T>(string rowText)
    {
        var result = JsonConvert.DeserializeObject<T>(rowText);

        return result;
    }

    public static string SerializeResponse<T>(T obj)
    {
        var json = JsonConvert.SerializeObject(obj);

        return json;
    }
}
