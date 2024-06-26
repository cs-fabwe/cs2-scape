using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs2_scape.Components.Layout;

partial class NavMenu
{
	public void GoToPage(string page)
	{
		Navigation.NavigateTo(page);
	}
}
