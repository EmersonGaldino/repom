using repom.domain.core.Entity;

namespace repom.domain.core.Interface;

public interface IPersonService
{
    Task<bool> CreateAsync(PersonEntity model);
    Task<List<PersonEntity>> GetAll();
}