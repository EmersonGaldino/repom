using AutoMapper;
using repom.application.api.Models;
using repom.domain.core.Entity;

namespace repom.application.api.AutoMapper;

public class MappingProfilesModelView : Profile
{
    public MappingProfilesModelView()
    {

        CreateMap<PersonEntity, PersonViewModel>().ReverseMap();
        CreateMap<JobEntity, JobViewModel>().ReverseMap();
        CreateMap<PhoneEntity, PhoneViewModel>().ReverseMap();
        CreateMap<DepartmentEntity, DepartmentViewModel>().ReverseMap();
        CreateMap<AddressEntity, AddressViewModel>().ReverseMap();
    }
}