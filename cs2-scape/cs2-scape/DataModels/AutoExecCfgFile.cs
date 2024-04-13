using cs2_scape.Enums;
using cs2_scape.Services;

namespace cs2_scape.DataModels;


public class AutoExecCfgFile(string path) : ICfgFile
{
    private readonly string _path = path;
    public ConfigFileTypes CfgType => ConfigFileTypes.Autoexec;

    public string GetFileContentAsString() => FileHandler.ReadFileContentAsString(_path);
    
}