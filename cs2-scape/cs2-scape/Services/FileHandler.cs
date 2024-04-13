using System.IO;

namespace cs2_scape.Services;

public static class FileHandler
{
    public static string ReadFileContentAsString(string filePath)
    {
        string content = "";
        try
        {
            StreamReader streamReader = new(filePath);
            content = streamReader.ReadToEnd();
            streamReader.Close();
        }
        catch (Exception)
        {
            content = "";
        }

        return content;
    }
}