using Microsoft.AspNetCore.Components;

namespace cs2_scape.Components;

partial class InfoBox : ComponentBase
{
    #region Properties
    [Parameter]
    public string Title { get; set; } = String.Empty;
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
    private bool IsExpanded { get; set; } = false;
    private string ExpandClass { get; set; } = "bx bx-plus";

    private readonly string _plusIcon = "bx bx-plus";
    private readonly string _minusIcon = "bx bx-minus";
    #endregion

    private void HandleExpand(EventArgs e)
    {
        IsExpanded = !IsExpanded;
        ExpandClass = IsExpanded ? _minusIcon : _plusIcon;
    }
}
