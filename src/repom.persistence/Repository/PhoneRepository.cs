using Microsoft.EntityFrameworkCore;
using repom.domain.core.Entity;
using repom.domain.core.Repositories;
using repom.persistence.Context;

namespace repom.persistence.Repository;

public class PhoneRepository(ContextDb context):  BaseRepository<PhoneEntity>(context), IPhoneRepository
{
    public async Task CreateAsync(PhoneEntity model) => await Add(model);
    public async Task<PhoneEntity> FindForNumber(string modelNumber) => 
        await context.Phone.FirstOrDefaultAsync(p=>p.Number == modelNumber);
   
}