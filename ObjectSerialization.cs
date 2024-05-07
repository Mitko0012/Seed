using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace Seed;

/// <summary>
/// A class that supports serialization of objects to JSON and XML.
/// </summary>
public static class ObjectSerialization
{
    /// <summary>
    /// Serializes an object in JSON and saves it in a file.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="ob">The object to be serialized.</param>
    /// <param name="filePath">The path where the file will be saved.</param>
    public static void SerializeJsonToFile<T>(T ob, string filePath)
    {
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.IncludeFields = true;
        string json = JsonSerializer.Serialize(ob, options);
        File.WriteAllText(filePath, json);
    }

    /// <summary>
    /// Serializes an object to JSON.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="ob">The object to be seiralized.</param>
    /// <returns>The JSON serialization of the object.</returns>
    public static string SerializeJson<T>(T ob)
    {
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.IncludeFields = true;
        return JsonSerializer.Serialize(ob, options);
    }
    /// <summary>
    /// Deserializes an object from a JSON file.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="filePath">The JSON source file.</param>
    /// <returns>A deserialized object from the JSON source.</returns>
    public static T? DeserializeJsonFromFile<T>(string filePath)
    {
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.IncludeFields = true;
        string json = File.ReadAllText(filePath);
        T? ob = JsonSerializer.Deserialize<T>(json, options);
        return ob;
    }

   /// <summary>
   /// Deserializes an object from JSON.
   /// </summary>
   /// <typeparam name="T">The type of the object.</typeparam>
   /// <param name="json">The JSON to be deserialized.</param>
   /// <returns>A deserialized object from the JSON source.</returns>
    public static T? DeserializeJson<T>(string json)
    {
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.IncludeFields = true;
        T? ob = JsonSerializer.Deserialize<T>(json, options);
        return ob;
    }

    /// <summary>
    /// Serializes an object in XML and saves it in a file.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="ob">The object to be serialized.</param>
    /// <param name="filePath">The path where the file will be saved.</param>
    public static void SerializeXmlToFile<T>(T ob, string filePath)
    {
        XmlSerializer ser = new XmlSerializer(typeof(T));
        StreamWriter write = new StreamWriter(filePath);
        ser.Serialize(write, ob);  
        write.Close(); 
    }

    /// <summary>
    /// Serializes an object to XML.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="ob">The object to be serialized.</param>
    /// <returns>The XML serialization of the object.</returns>
    public static string SerializeXml<T>(T ob)
    {
        XmlSerializer ser = new XmlSerializer(typeof(T));
        StringWriter write = new StringWriter();
        ser.Serialize(write, ob);  
        write.Close();
        return write.ToString(); 
    }

    /// <summary>
    /// Deserializes an object from an XML file.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="filePath">The XML source file.</param>
    /// <returns>A deserialized object from the XML source.</returns>
    public static T? DeserializeXmlFromFile<T>(string filePath)
    {
        XmlSerializer ser = new XmlSerializer(typeof(T));
        TextReader text = new StreamReader(filePath);
        T? ob = (T?)ser.Deserialize(text);
        return ob;
    }

    /// <summary>
    /// Deserializes an object from XML.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="xml">The XML to be deserialized.</param>
    /// <returns>A deserialized object from the XML source.</returns>
    public static T? DeserializeXml<T>(string xml)
    {
        XmlSerializer ser = new XmlSerializer(typeof(T));
        TextReader text = new StringReader(xml);
        T? ob = (T?)ser.Deserialize(text);
        return ob;
    }
}