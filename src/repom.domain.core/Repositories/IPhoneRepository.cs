using repom.domain.core.Entity;

namespace repom.domain.core.Repositories;

public interface IPhoneRepository
{
    Task CreateAsync(PhoneEntity phoneEntity);
    Task<PhoneEntity> FindForNumber(string modelNumber);
}