using repom.domain.core.Entity;
using repom.domain.core.Interface;
using repom.domain.core.Repositories;

namespace repom.domain.core.Service;

public class AddressService(IAddressRepository repository) : IAddressService
{
    public async Task<int> CreateAsync(AddressEntity model)
    {
        var exists = await repository.GetForStreetAsync(model.Street);
        if (exists != null)
            return exists.id;
        await repository.SaveAsync(model);
        return model.id;
    }
}