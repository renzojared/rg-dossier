
namespace WebGui.Layout;

public partial class MainLayoutSample
{
    bool Open;
    void OpenClose() => Open = !Open;
    
    private readonly MudTheme _governmentTheme = new()
    {
        Palette = new Palette
        {
            AppbarBackground = Colors.Green.Darken4,
            
        }
    };
}