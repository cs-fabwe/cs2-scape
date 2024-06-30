

using Microsoft.AspNetCore.Components;

namespace cs2_scape.Components.Pages;

public partial class Home : ComponentBase
{
    private readonly List<string> Options = ["Option 1", "Option 2", "Option 3"];
    public string val = String.Empty;

    public void ValChange(string newval)
    {
        val = newval;
    }
}

