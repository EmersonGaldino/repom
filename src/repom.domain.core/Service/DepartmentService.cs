using repom.domain.core.Entity;
using repom.domain.core.Interface;
using repom.domain.core.Repositories;

namespace repom.domain.core.Service;

public class DepartmentService(IDepartmentRepository repository) : IDepartmentService
{
    public async Task<int> CreateAsync(DepartmentEntity model)
    {
        var exist = await repository.GetForDescriptionAsync(model.Description);
        if (exist != null)
            return exist.id;
        await repository.CreateAsync(model);
        return model.id;
    }
}