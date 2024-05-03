using System.Reflection;

namespace Seed;

public abstract class ResourceLoader
{
    public static Assembly CurrAssembly = Assembly.GetExecutingAssembly();
    public static Bitmap LoadImg(string path)
    {
        Stream? textureStream = CurrAssembly.GetManifestResourceStream(path);
        return textureStream == null? new Bitmap(1, 1) : new Bitmap(textureStream);
    }

    public static string LoadTextFile(string path)
    {
        Stream? fileStream = CurrAssembly.GetManifestResourceStream(path);
        return fileStream == null? "" : new StreamReader(fileStream).ReadToEnd();
    }
}