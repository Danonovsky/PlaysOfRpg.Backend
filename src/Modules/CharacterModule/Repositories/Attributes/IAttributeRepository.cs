using Abstractions.Repositories;
using Attribute = CharacterModule.DAL.Entities.Attribute;

namespace CharacterModule.Repositories.Attributes;

public interface IAttributeRepository : ICrudRepository<Attribute>
{
    
}