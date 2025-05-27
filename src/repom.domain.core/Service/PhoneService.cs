using repom.domain.core.Entity;
using repom.domain.core.Interface;
using repom.domain.core.Repositories;

namespace repom.domain.core.Service;

public class PhoneService(IPhoneRepository repository) : IPhoneService
{
    public async Task<int> CreateAsync(PhoneEntity model)
    {
        var exist = await repository.FindForNumber(model.Number);

        if (exist != null)
            return exist.id;
        await repository.CreateAsync(model);
        return model.id;
    }
    
}