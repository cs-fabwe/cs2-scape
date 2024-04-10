using System.Net;
using System.Windows.Documents;
using cs2_scape.Enums;

namespace cs2_scape.Repositories;

public class UserFilesRepository
{
    private readonly List<(ConfigFileTypes, string)> _userFiles = new();
    /// <summary>
    /// Adds a file to the User file repository
    /// </summary>
    /// <param name="cfgType"></param>
    /// <param name="fileName"></param>
    public void AddFile(ConfigFileTypes cfgType, string fileName)
    {
        int itemFoundIndex = -1;
        
        foreach (var item in _userFiles)
        {
            if (item.Item1 == cfgType && cfgType != ConfigFileTypes.Custom)
                itemFoundIndex = _userFiles.IndexOf(item);
        }

        if (itemFoundIndex >= 0)
        {
            _userFiles[itemFoundIndex] = (cfgType, fileName);
            return;
        }
        _userFiles.Add((cfgType, fileName));
    }


    /// <summary>
    /// Gets the file-path of a config file thats not typeof ConfigFileTypes.Custom since
    /// custom configs can be available more than once
    /// </summary>
    /// <param name="cfgType"></param>
    /// <returns></returns>
    public string GetExclusiveConfigFile(ConfigFileTypes cfgType)
    {
        if (_userFiles.Count <= 0)
            return String.Empty;
        if (cfgType == ConfigFileTypes.Custom)
            return String.Empty;
        
        var fileNames = 
            _userFiles.Where(itm => itm.Item1 == cfgType).ToList();

        return fileNames.First().Item2;
    }

    public List<String>? GetCustomConfigFiles()
    {
        if (_userFiles.Count <= 0)
            return null;

        var query =
            (from item in _userFiles
                where item.Item1 == ConfigFileTypes.Custom
                select item.Item2).ToList();
        return query;
    }
}