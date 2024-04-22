namespace Domain.Enums;

public static class EnumDomainExtensions
{
    public static string GetTitleEnumDescription(this Enum value)
    {
        var enumType = value.GetType();
        var titleDescription =
            (DescriptionAttribute)Attribute.GetCustomAttribute(enumType, typeof(DescriptionAttribute));
        return titleDescription?.Description ?? value.ToString();
    }
    public static string GetEnumDescription(this Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        var descriptionAttribute =
            (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));
        return descriptionAttribute?.Description ?? value.ToString();
    }
}