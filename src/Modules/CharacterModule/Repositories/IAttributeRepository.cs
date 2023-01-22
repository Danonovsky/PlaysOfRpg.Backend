using Abstractions.Repositories;
using Attribute = CharacterModule.DAL.Entities.Attribute;

namespace CharacterModule.Repositories;

public interface IAttributeRepository : ICrudRepository<Attribute>
{
    
}