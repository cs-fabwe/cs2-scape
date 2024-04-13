using cs2_scape.Enums;

namespace cs2_scape.DataModels;

public interface ICfgFile
{
    ConfigFileTypes CfgType { get; }
    string GetFileContentAsString();
}