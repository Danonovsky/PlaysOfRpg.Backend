using Abstractions.Repositories;
using Attribute = CharacterModule.Entities.Attribute;

namespace CharacterModule.Repositories;

public interface IAttributeRepository : ICrudRepository<Attribute>
{
    
}