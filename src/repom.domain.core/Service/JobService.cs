using repom.domain.core.Entity;
using repom.domain.core.Interface;
using repom.domain.core.Repositories;

namespace repom.domain.core.Service;

public class JobService(IJobRepository repository) : IJobService
{
    public async Task<int> CreateAsync(JobEntity model)
    {
        var existingJob = await repository.GetForDescriptionAsync(model.Description);

        if (existingJob != null)
            return existingJob.id;

        await repository.CreateAsync(model);
    
        return model.id;
    } 

}