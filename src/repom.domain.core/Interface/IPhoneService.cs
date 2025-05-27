using repom.domain.core.Entity;

namespace repom.domain.core.Interface;

public interface IPhoneService
{
    Task<int> CreateAsync(PhoneEntity modelPhones);
}