using Abstractions.Models;

namespace CharacterModule.DAL.Entities;

public class Attribute : BaseEntity
{
    public string Name { get; set; } = "Default Attribute";
    public int Value { get; set; }

    public AttributeDto AsDto => new AttributeDto(Id, Name, Value);
}

public record AddAttribute(string Name, int Value);
public record UpdateAttribute(string Name, int Value);
public record AttributeDto(Guid Id, string Name, int Value);