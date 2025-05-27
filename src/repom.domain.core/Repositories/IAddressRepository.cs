using repom.domain.core.Entity;

namespace repom.domain.core.Repositories;

public interface IAddressRepository
{
    Task<int> SaveAsync(AddressEntity modelAddress);
    Task<AddressEntity> GetForStreetAsync(string modelAddressStreet);
}