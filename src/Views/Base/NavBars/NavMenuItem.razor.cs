namespace Views.Base.NavBars;

public partial class NavMenuItem
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }
    [Parameter]
    public string FielValue { get; set; }
    [Parameter]
    public string Href { get; set; }
    [Parameter]
    public NavLinkMatch Match { get; set; }
    [Parameter]
    public string Icon { get; set; } = Icons.Material.Filled.FilterNone;
}