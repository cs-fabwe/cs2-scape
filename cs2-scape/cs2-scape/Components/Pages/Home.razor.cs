using System.Windows;
using System.Windows.Controls;
using cs2_scape.Services;
using Microsoft.AspNetCore.Components;

namespace cs2_scape.Components.Pages;

public partial class Home : ComponentBase
{

    private string Message { get; set; } = "Hello World!";
    private int HelloCounter { get; set; }
    private bool ShowSelection { get; set; } = false;
    private string SelectionMenuClass { get; set; } = "selection-menu-inactive";
    private string? InputFieldData { get; set; }
    private bool InputFieldDisabled { get; set; } = false;
    private string InputFieldClass { get; set; } = "";
    private string LoaderClass { get; set; } = "hidden";
    private string CheckClass { get; set; } = "hidden";
    private string ButtonClass { get; set; } = "hidden";
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
    private async Task GetSteamPathFromOpenFolderDialog()
    {
        ButtonClass = "btn";
        InputFieldClass = "hidden";
        LoaderClass = "loader";
        StateHasChanged();
        var folderPath = FileHandler.GetFolderPathWithOpenFolderDialog();
        await Task.Delay(3000);
        if (folderPath.EndsWith(@"\userdata"))
        {
            InputFieldData = folderPath;
            LoaderClass = "hidden";
            CheckClass = "";
            StateHasChanged();
        }
        else
        {
            InputFieldClass = "";
            ButtonClass = "hidden";
        }
        StateHasChanged();
    }
}