using Abstractions.Models;

namespace CharactersModule.Entities;

public class Skill : BaseEntity
{
    public string Name { get; set; } = "Default Skill";
    public int Value { get; set; }
}