using repom.domain.core.Entity;

namespace repom.domain.core.Repositories;

public interface IJobRepository
{
    Task<int> CreateAsync(JobEntity model);
    Task<JobEntity> GetForDescriptionAsync(string modelDescription);
}