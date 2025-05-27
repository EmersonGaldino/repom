using Microsoft.EntityFrameworkCore;
using repom.domain.core.Entity;
using repom.domain.core.Repositories;
using repom.persistence.Context;

namespace repom.persistence.Repository;

public class JobRepository(ContextDb context):  BaseRepository<JobEntity>(context), IJobRepository
{
    public async Task<int> CreateAsync(JobEntity model) => await Add(model);
    public async Task<JobEntity> GetForDescriptionAsync(string modelDescription) => 
        await context.Job.FirstOrDefaultAsync(j =>j.Description == modelDescription);
   
}