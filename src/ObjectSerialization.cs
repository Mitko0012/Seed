using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace Seed;

public static class ObjectSerialization
{
    public static void SerializeJsonToFile<T>(T ob, string filePath)
    {
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.IncludeFields = true;
        string json = JsonSerializer.Serialize(ob, options);
        File.WriteAllText(filePath, json);
    }

    public static string SerializeJson<T>(T ob)
    {
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.IncludeFields = true;
        return JsonSerializer.Serialize(ob, options);
    }
    public static T? DeserializeJsonFromFile<T>(string filePath)
    {
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.IncludeFields = true;
        string json = File.ReadAllText(filePath);
        T? ob = JsonSerializer.Deserialize<T>(json, options);
        return ob;
    }

    public static T? DeserializeJson<T>(string json)
    {
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.IncludeFields = true;
        T? ob = JsonSerializer.Deserialize<T>(json, options);
        return ob;
    }

    public static void SerializeXmlToFile<T>(T ob, string filePath)
    {
        XmlSerializer ser = new XmlSerializer(typeof(T));
        StreamWriter write = new StreamWriter(filePath);
        ser.Serialize(write, ob);  
        write.Close(); 
    }

    public static string SerializeXml<T>(T ob)
    {
        XmlSerializer ser = new XmlSerializer(typeof(T));
        StringWriter write = new StringWriter();
        ser.Serialize(write, ob);  
        write.Close();
        return write.ToString(); 
    }

    public static T? DeserializeXmlFromFile<T>(string filePath)
    {
        XmlSerializer ser = new XmlSerializer(typeof(T));
        TextReader text = new StreamReader(filePath);
        T? ob = (T?)ser.Deserialize(text);
        return ob;
    }

    public static T? DeserializeXml<T>(string xml)
    {
        XmlSerializer ser = new XmlSerializer(typeof(T));
        TextReader text = new StringReader(xml);
        T? ob = (T?)ser.Deserialize(text);
        return ob;
    }
}