using Microsoft.EntityFrameworkCore;
using repom.domain.core.Entity;
using repom.domain.core.Repositories;
using repom.persistence.Context;

namespace repom.persistence.Repository;

public class DepartmentRepository(ContextDb context):  BaseRepository<DepartmentEntity>(context), IDepartmentRepository
{
    public async Task<int> CreateAsync(DepartmentEntity model) => await Add(model);

    public async Task<DepartmentEntity> GetForDescriptionAsync(string modelDescription) =>
        await context.Department.FirstOrDefaultAsync(d => d.Description == modelDescription);

}