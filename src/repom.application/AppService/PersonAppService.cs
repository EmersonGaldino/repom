using System.Collections.Generic;
using System.Threading.Tasks;
using repom.application.Interface;
using repom.domain.core.Entity;
using repom.domain.core.Interface;

namespace repom.application.AppService;

public class PersonAppService(IPersonService service) : IPersonAppService
{
    public async Task<bool> CreateAsync(PersonEntity model) => await service.CreateAsync(model);
    public async Task<List<PersonEntity>> GetAll() => await service.GetAll();

}