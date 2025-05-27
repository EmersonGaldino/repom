using System.Collections.Generic;
using System.Threading.Tasks;
using repom.domain.core.Entity;

namespace repom.application.Interface;

public interface IPersonAppService
{
    Task<bool> CreateAsync(PersonEntity model);
    Task<List<PersonEntity>> GetAll();
}