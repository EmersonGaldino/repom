using repom.domain.core.Entity;
using repom.domain.core.Interface;
using repom.domain.core.Repositories;

namespace repom.domain.core.Service;

public class PersonService(
    IPersonRepository repository,
    IJobService jobService,
    IAddressService addressService,
    IDepartmentService departmentService,
    IPhoneService phoneService) : IPersonService
{
    public async Task<bool> CreateAsync(PersonEntity model)
    {
        model.Job.departmentId = await departmentService.CreateAsync(model.Job.Department);

        var address = await addressService.CreateAsync(model.Address);

        model.JobId = await jobService.CreateAsync(model.Job);

        var existingPerson = await repository.FindForCpfPersonAsync(model.CPF);
        if (existingPerson != null)
            return false;
        model.AddressId = address;
        var person = await repository.CreateAsync(model);
        foreach (var phone in model.Phones)
        {
            phone.PersonId = person;
            await phoneService.CreateAsync(phone);
        }

        return true;
    }

    public async Task<List<PersonEntity>> GetAll() => await repository.GetAll();
}