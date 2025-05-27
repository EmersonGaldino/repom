using repom.domain.core.Entity;

namespace repom.domain.core.Interface;

public interface IDepartmentService
{
    Task<int> CreateAsync(DepartmentEntity jobDepartament);
}