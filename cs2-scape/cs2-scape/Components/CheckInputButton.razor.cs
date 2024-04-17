using Microsoft.AspNetCore.Components;

namespace cs2_scape.Components;

public partial class CheckInputButton : ComponentBase
{
    private enum State : int
    {
        Default = 1,
        Loading = 2,
        Sucessful = 3
    }
    [Parameter] public string? Text { get; set; } = "";
    [Parameter] public EventCallback OnClickCheckMethod { get; set; }
    [Parameter] public EventCallback OnClickOnSuccessfullCheck { get; set; }
    private State state = default;
    private string LoaderClass { get; set; } = "hidden";
    private string CheckClass { get; set; } = "hidden";
    private string TextClass { get; set; } = "";

    private void SetStateDefault()
    {
        LoaderClass = "hidden";
        CheckClass = "hidden";
        TextClass = "";
        state = State.Default;
    }

    private void SetStateLoading()
    {
        LoaderClass = "loader";
        CheckClass = "hidden";
        TextClass = "hidden";
        state = State.Loading;
    }

    private void SetStateSuccessful()
    {
        LoaderClass = "hidden";
        CheckClass = "";
        TextClass = "hidden";
        state = State.Sucessful;
    }

    private async Task HandleOnClick()
    {
        if (state == State.Default)
        {
            SetStateLoading();
            await OnClickCheckMethod.InvokeAsync();
        }
        else if (state == State.Sucessful)
        {
            SetStateDefault();
            await OnClickOnSuccessfullCheck.InvokeAsync();
        }
    }

}