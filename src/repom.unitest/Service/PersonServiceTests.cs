using System.ComponentModel;
using Moq;
using repom.domain.core.Entity;
using repom.domain.core.Interface;
using repom.domain.core.Repositories;
using repom.domain.core.Service;

namespace repom.unitest.Service;

public class PersonServiceTests
{
    private readonly Mock<IPersonRepository> _repositoryMock = new();
    private readonly Mock<IJobService> _jobServiceMock = new();
    private readonly Mock<IAddressService> _addressServiceMock = new();
    private readonly Mock<IDepartmentService> _departmentServiceMock = new();
    private readonly Mock<IPhoneService> _phoneServiceMock = new();

    private readonly PersonService _service;

    public PersonServiceTests()
    {
        _service = new PersonService(
            _repositoryMock.Object,
            _jobServiceMock.Object,
            _addressServiceMock.Object,
            _departmentServiceMock.Object,
            _phoneServiceMock.Object
        );
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnTrue_WhenPersonIsNew()
    {
        var person = new PersonEntity
        {
            CPF = "12345678901",
            Address = new AddressEntity(),
            Job = new JobEntity
            {
                Department = new DepartmentEntity()
            },
            Phones = new List<PhoneEntity>
            {
                new() { Number = "99999999999", Type = "Mobile" }
            }
        };

        _departmentServiceMock.Setup(x => x.CreateAsync(It.IsAny<DepartmentEntity>())).ReturnsAsync(1);
        _addressServiceMock.Setup(x => x.CreateAsync(It.IsAny<AddressEntity>())).ReturnsAsync(2);
        _jobServiceMock.Setup(x => x.CreateAsync(It.IsAny<JobEntity>())).ReturnsAsync(3);
        _repositoryMock.Setup(x => x.FindForCpfPersonAsync(It.IsAny<string>())).ReturnsAsync((PersonEntity)null);
        _repositoryMock.Setup(x => x.CreateAsync(It.IsAny<PersonEntity>())).ReturnsAsync(10);

        var result = await _service.CreateAsync(person);
        Assert.True(result);
        _repositoryMock.Verify(x => x.CreateAsync(It.IsAny<PersonEntity>()), Times.Once);
        _phoneServiceMock.Verify(x => x.CreateAsync(It.Is<PhoneEntity>(p => p.PersonId == 10)), Times.Once);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnFalse_WhenPersonAlreadyExists()
    {
        var person = new PersonEntity
        {
            CPF = "989765432100",
            Address = new AddressEntity
            {
                Street = "Main St",
                City = "Testville",
                State = "TS",
                ZipCode = "12345678",
                Number = "123"
            },
            Job = new JobEntity
            {
                Description = "Dev",
                Salary = 1000,
                StartDate = DateTime.UtcNow,
                Department = new DepartmentEntity
                {
                    Description = "IT"
                }
            },
            Phones = new List<PhoneEntity>
            {
                new PhoneEntity { Number = "11999999999", Type = "Mobile" }
            }
        };
        _repositoryMock.Setup(x => x.FindForCpfPersonAsync(person.CPF)).ReturnsAsync(new PersonEntity());

        var result = await _service.CreateAsync(person);

        Assert.False(result);
        _repositoryMock.Verify(x => x.CreateAsync(It.IsAny<PersonEntity>()), Times.Never);
    }
    [Fact]
    public async Task CreateAsync_ShouldCreatePerson_WhenPersonDoesNotExist()
    {
        var person = new PersonEntity
        {
            CPF = "9876543210",
            Address = new AddressEntity
                { Street = "Rua A", City = "X", State = "XX", ZipCode = "00000000", Number = "1" },
            Job = new JobEntity
            {
                Description = "Dev",
                Salary = 1500,
                StartDate = DateTime.UtcNow,
                Department = new DepartmentEntity { Description = "TI" }
            },
            Phones = new List<PhoneEntity> { new PhoneEntity { Number = "11999999999", Type = "Mobile" } }
        };

        _departmentServiceMock.Setup(x => x.CreateAsync(It.IsAny<DepartmentEntity>())).ReturnsAsync(1);
        _addressServiceMock.Setup(x => x.CreateAsync(It.IsAny<AddressEntity>())).ReturnsAsync(1);
        _jobServiceMock.Setup(x => x.CreateAsync(It.IsAny<JobEntity>())).ReturnsAsync(1);
        _repositoryMock.Setup(x => x.FindForCpfPersonAsync(person.CPF)).ReturnsAsync((PersonEntity)null);
        _repositoryMock.Setup(x => x.CreateAsync(It.IsAny<PersonEntity>())).ReturnsAsync(1);

        var result = await _service.CreateAsync(person);

        Assert.True(result);
        _repositoryMock.Verify(x => x.CreateAsync(It.IsAny<PersonEntity>()), Times.Once);
        _phoneServiceMock.Verify(x => x.CreateAsync(It.IsAny<PhoneEntity>()), Times.Once);
    }

    [Fact]
    public async Task CreateAsync_ShouldThrowException_WhenJobIsNull()
    {

        await Assert.ThrowsAsync<NullReferenceException>(() => _service.CreateAsync(new PersonEntity
        {
            CPF = "12345678901",
            Job = null
        }));
    }

    [Fact]
    public async Task CreateAsync_ShouldNotCreatePhone_WhenPhoneListIsEmpty()
    {
        var person = new PersonEntity
        {
            CPF = "12345678901",
            Address = new AddressEntity
                { Street = "Rua A", City = "X", State = "XX", ZipCode = "00000000", Number = "1" },
            Job = new JobEntity
            {
                Description = "Dev",
                Salary = 1500,
                StartDate = DateTime.UtcNow,
                Department = new DepartmentEntity { Description = "TI" }
            },
            Phones = new List<PhoneEntity>() // Lista vazia
        };

        _departmentServiceMock.Setup(x => x.CreateAsync(It.IsAny<DepartmentEntity>())).ReturnsAsync(1);
        _addressServiceMock.Setup(x => x.CreateAsync(It.IsAny<AddressEntity>())).ReturnsAsync(1);
        _jobServiceMock.Setup(x => x.CreateAsync(It.IsAny<JobEntity>())).ReturnsAsync(1);
        _repositoryMock.Setup(x => x.FindForCpfPersonAsync(person.CPF)).ReturnsAsync((PersonEntity)null);
        _repositoryMock.Setup(x => x.CreateAsync(It.IsAny<PersonEntity>())).ReturnsAsync(1);

        var result = await _service.CreateAsync(person);

        Assert.True(result);
        _phoneServiceMock.Verify(x => x.CreateAsync(It.IsAny<PhoneEntity>()), Times.Never);
    }
    [Fact]
    public async Task GetAll_ShouldReturnListOfPeople()
    {
        var people = new List<PersonEntity>
        {
            new () { id = 1, CPF = "12345678901" },
            new () { id = 2, CPF = "98765432100" }
        };

        _repositoryMock.Setup(x => x.GetAll()).ReturnsAsync(people);

        var result = await _service.GetAll();

        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
    }
    
    [Fact]
    [Description("Smoke test")]
    public void Constructor_ShouldCreateInstance()
    {
        var service = new PersonService(
            _repositoryMock.Object,
            _jobServiceMock.Object,
            _addressServiceMock.Object,
            _departmentServiceMock.Object,
            _phoneServiceMock.Object
        );

        Assert.NotNull(service);
    }


}