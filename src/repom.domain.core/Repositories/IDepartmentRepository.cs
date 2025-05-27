using repom.domain.core.Entity;

namespace repom.domain.core.Repositories;

public interface IDepartmentRepository
{
    Task<int> CreateAsync(DepartmentEntity model);
    Task<DepartmentEntity> GetForDescriptionAsync(string modelDescription);
}