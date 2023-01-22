using Abstractions.Repositories;
using Attribute = CharactersModule.Entities.Attribute;

namespace CharactersModule.Repositories;

public interface IAttributeRepository : ICrudRepository<Attribute>
{
    
}