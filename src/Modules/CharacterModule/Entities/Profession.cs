using Abstractions.Models;

namespace CharacterModule.Entities;

public class Profession : BaseEntity
{
    public string Name { get; set; } = "Default Profession";
    public List<Tuple<Attribute, int>> MainAttributes { get; set; } = new();
    public List<Skill> Skills { get; set; } = new();
}