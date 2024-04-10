

using Microsoft.AspNetCore.Components;

namespace cs2_scape.Components.Pages;

public partial class Home : ComponentBase
{
    private string Message { get; set; } = "Hello World!";
    private int HelloCounter { get; set; }
    private async Task ChangeMessageAsync()
    {
        await Task.Run(
            () => HelloCounter++
            );
        Message = $"You said Hello {HelloCounter}x times!";
        StateHasChanged();
    }
}