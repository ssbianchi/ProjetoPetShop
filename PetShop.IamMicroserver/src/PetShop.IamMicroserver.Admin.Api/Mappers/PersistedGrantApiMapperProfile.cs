using AutoMapper;
using PetShop.IamMicroserver.Admin.Api.Dtos.PersistedGrants;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Dtos.Grant;

namespace PetShop.IamMicroserver.Admin.Api.Mappers
{
    public class PersistedGrantApiMapperProfile : Profile
    {
        public PersistedGrantApiMapperProfile()
        {
            CreateMap<PersistedGrantDto, PersistedGrantApiDto>(MemberList.Destination);
            CreateMap<PersistedGrantDto, PersistedGrantSubjectApiDto>(MemberList.Destination);
            CreateMap<PersistedGrantsDto, PersistedGrantsApiDto>(MemberList.Destination);
        }
    }
}





