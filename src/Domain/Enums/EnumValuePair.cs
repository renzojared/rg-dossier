using System.ComponentModel;

namespace Domain.Enums;

public static class EnumValuePair
{
    public static string GetEnumDescription(this Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        var descriptionAttribute =
            (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));
        return descriptionAttribute?.Description ?? value.ToString();
    }
}