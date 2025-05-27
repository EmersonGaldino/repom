using repom.domain.core.Entity;

namespace repom.domain.core.Interface;

public interface IAddressService
{
    Task<int> CreateAsync(AddressEntity modelAddress);
}