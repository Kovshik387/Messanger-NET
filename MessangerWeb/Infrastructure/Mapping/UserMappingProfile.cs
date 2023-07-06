using AutoMapper;
using BLL.DTOs;
using MessangerWeb.Models;

namespace MessangerWeb.Infrastructure.Mapping
{
    public class UserMappingProfile : Profile
    {
		public UserMappingProfile()
		{
			CreateMap<UserView, AuthentificationDTO>().ReverseMap();
			CreateMap<UserView, UserDTO>().ReverseMap();
		}
	}
}
