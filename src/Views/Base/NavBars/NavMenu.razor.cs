namespace Views.Base.NavBars;

public partial class NavMenu
{
    [Parameter] public RenderFragment NavBarBrand { get; set; }
    [Parameter] public RenderFragment NavBarItems { get; set; }

    private bool _open = false;
    private void ToggleDrawer() => _open = !_open;
}