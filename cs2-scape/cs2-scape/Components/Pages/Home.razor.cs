using System.Windows;
using Microsoft.AspNetCore.Components;

namespace cs2_scape.Components.Pages;

public partial class Home : ComponentBase
{

    private string Message { get; set; } = "Hello World!";
    private int HelloCounter { get; set; }
    private bool ShowSelection { get; set; } = false;
    private string SelectionMenuClass { get; set; } = "selection-menu-inactive";
    private async Task ChangeMessageAsync()
    {
        await Task.Run(
            () => HelloCounter++
            );
        Message = $"You said Hello {HelloCounter}x times!";
        StateHasChanged();
    }

    private void ToggleFileSelection()
    {
        ShowSelection = !ShowSelection;
        SelectionMenuClass = ShowSelection ? "selection-menu" : "selection-menu-inactive";
        StateHasChanged();
    }
    private void OpenFileDialogForFolders()
    {
        MessageBox.Show("Open a file dialog here");
    }
}