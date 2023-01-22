using Abstractions.Models;

namespace CharacterModule.Entities;

public class Skill : BaseEntity
{
    public string Name { get; set; } = "Default Skill";
    public int Value { get; set; }
}