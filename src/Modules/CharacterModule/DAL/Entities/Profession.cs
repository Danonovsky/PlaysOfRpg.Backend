using Abstractions.Models;
using CharacterModule.Entities;

namespace CharacterModule.DAL.Entities;

public class Profession : BaseEntity
{
    public string Name { get; set; } = "Default Profession";
    public List<Tuple<Attribute, int>> MainAttributes { get; set; } = new();
    public List<Skill> Skills { get; set; } = new();
}