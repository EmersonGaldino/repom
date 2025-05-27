using Microsoft.EntityFrameworkCore;
using repom.domain.core.Entity;
using repom.domain.core.Repositories;
using repom.persistence.Context;

namespace repom.persistence.Repository;

public class PersonRepository(ContextDb context) : BaseRepository<PersonEntity>(context), IPersonRepository
{
    public async Task<int> CreateAsync(PersonEntity model) => await Add(model);

    public async Task<PersonEntity> FindForCpfPersonAsync(string modelCpf) =>
        await context.Person.FirstOrDefaultAsync(p => p.CPF == modelCpf);

    public async Task<List<PersonEntity>> GetAll() =>
        await context.Person
            .Include(p => p.Address)
            .Include(p=>p.Phones)
            .Include(p => p.Job)
            .ThenInclude(p => p.Department).ToListAsync();

}