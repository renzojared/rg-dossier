namespace Gateways.Options;

public class WebApiOptions
{
    public const string SectionKey = nameof(WebApiOptions);
    public string BaseAddress { get; set; }
    public double TimeOutInSeconds { get; set; }
}