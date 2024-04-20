namespace Views.Components.Common;

public partial class PersonComp
{
    [Parameter] public PersonVm Person { get; set; }
    [Parameter] public int SmValue { get; set; } = 6;
    [Parameter] public int MdValue { get; set; } = 6;
    [Parameter] public int LgValue { get; set; } = 6;
}
