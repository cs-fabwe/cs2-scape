using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;

namespace cs2_scape.Components;

public partial class LoadingSpinner : ComponentBase
{
    [Parameter] public string? LoaderText { get; set; } = "Loading";


}