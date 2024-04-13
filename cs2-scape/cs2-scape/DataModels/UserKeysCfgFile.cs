using cs2_scape.Enums;
using cs2_scape.Services;

namespace cs2_scape.DataModels;

public class UserKeysCfgFile(string path) : ICfgFile
{
    private readonly string _path = path;
    public ConfigFileTypes CfgType => ConfigFileTypes.UserKeys;

    public string GetFileContentAsString() => FileHandler.ReadFileContentAsString(_path);
}