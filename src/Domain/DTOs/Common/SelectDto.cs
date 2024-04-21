namespace Domain.DTOs.Common;

public class SelectDto : BaseEntity
{
    public string Description { get; set; }
}

public class NameSelectDto : BaseEntity
{
    public string Name { get; set; }
}

public class FullNameSelectDto : BaseEntity
{
    public string FullName { get; set; }
}