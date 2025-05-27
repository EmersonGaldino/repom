using Microsoft.EntityFrameworkCore;
using repom.domain.core.Entity;
using repom.domain.core.Repositories;
using repom.persistence.Context;

namespace repom.persistence.Repository;

public class AddressRepository(ContextDb context) : BaseRepository<AddressEntity>(context), IAddressRepository
{
    public async Task<int> SaveAsync(AddressEntity modelAddress) => await Add(modelAddress);

    public async Task<AddressEntity> GetForStreetAsync(string modelAddressStreet) =>
        await context.Address.FirstOrDefaultAsync(a => a.Street == modelAddressStreet);
}