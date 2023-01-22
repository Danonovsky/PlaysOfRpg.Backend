using Abstractions.Models;

namespace CharacterModule.Entities;

public class Attribute : BaseEntity
{
    public string Name { get; set; } = "Default Attribute";
    public int Value { get; set; }
}