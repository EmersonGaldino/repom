using repom.domain.core.Entity;

namespace repom.domain.core.Interface;

public interface IJobService
{
    Task<int> CreateAsync(JobEntity modelJob);
}