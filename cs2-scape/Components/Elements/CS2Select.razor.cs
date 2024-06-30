using Microsoft.AspNetCore.Components;

namespace cs2_scape.Components.Elements;

public partial class CS2Select : ComponentBase
{
    #region Properties
      
    private string selectedValue = String.Empty;
    
    public string SelectedValue
    {
        get => selectedValue;
        set { 
            selectedValue = value;
            ValueChanged.InvokeAsync(value);
        }
    }
    #endregion
    #region Parameters

    [Parameter]
    public List<string> Options { get; set; } = [];
    [Parameter]
    public EventCallback<string> ValueChanged { get; set; }
    [Parameter]
    public string Label { get; set; } = String.Empty;
    #endregion

    protected override void OnInitialized()
    {
        if(Options.Count > 0)
            SelectedValue = Options[0];
    }
}
