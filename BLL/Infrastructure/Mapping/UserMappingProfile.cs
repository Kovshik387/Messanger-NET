using AutoMapper;
using BLL.DTOs;
using DAL.Models;

namespace BLL.Infrastructure.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() => CreateMap<User, AuthentificationDTO>()
            .ForMember(r => r.Role,
            option => option.MapFrom(role => role.IdAuthorizeNavigation.IdRoleNavigation.Type));
    }
}
