namespace cs2_scape.Components.Layout;

public partial class NavMenu
{
	public void GoToPage(string page)
	{
		Navigation.NavigateTo(page);
	}
}
