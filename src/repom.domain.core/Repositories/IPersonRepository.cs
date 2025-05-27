using repom.domain.core.Entity;

namespace repom.domain.core.Repositories;

public interface IPersonRepository
{
    Task<int> CreateAsync(PersonEntity model);
    Task<PersonEntity> FindForCpfPersonAsync(string modelCpf);
    Task<List<PersonEntity>> GetAll();
}