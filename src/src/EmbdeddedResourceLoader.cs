using System.Reflection;

namespace Seed;

/// <summary>
/// This class contains methods for loading embedded resources.
/// </summary>
public static class EmbdeddedResourceLoader
{
    /// <summary>
    /// Represents the current assembly of the program. Has to be initialized before resources could be loaded.
    /// </summary>
    public static Assembly? CurrAssembly;
    
    /// <summary>
    /// Loads an embedded image resource.
    /// </summary>
    /// <param name="name">The name of the resource</param>
    /// <returns>The resource represented as a <c>Bitmap</c> object</returns>
    /// <exception cref="Exception">Thrown if the resource can't found.</exception>
    public static Bitmap LoadImg(string name)
    {
        Stream? textureStream = CurrAssembly == null? null : CurrAssembly.GetManifestResourceStream(name);
        if(textureStream == null)
            throw new Exception("Resource not found");
        return new Bitmap(textureStream);
    }

    /// <summary>
    /// Loads an embedded text file resource.
    /// </summary>
    /// <param name="name">The name of the resource</param>
    /// <returns>The resource's contents.</returns>
    /// <exception cref="Exception">Thrown if the resource can't found.</exception>
    public static string LoadTextFile(string name)
    {
        Stream? fileStream = CurrAssembly == null? null : CurrAssembly.GetManifestResourceStream(name);
        if(fileStream == null)
            throw new Exception("Resource not found");  
        return new StreamReader(fileStream).ReadToEnd();
    }
}