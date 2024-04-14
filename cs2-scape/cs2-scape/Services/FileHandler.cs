using System.IO;
using Microsoft.Win32;

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

    public static string GetFolderPathWithOpenFolderDialog()
    {
        var ofd = new OpenFolderDialog()
        {
            AddToRecent = false,
            DefaultDirectory = @"C:\",
            Title = "Please select the Steam userdata folder",
            RootDirectory = @"C:\"
        };

        if (ofd.ShowDialog() == false)
            return "";
        
        return ofd.FolderName;
    }
}