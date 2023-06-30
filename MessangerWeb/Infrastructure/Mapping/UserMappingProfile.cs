using AutoMapper;
using BLL.DTOs;
using MessangerWeb.Models;

namespace MessangerWeb.Infrastructure.Mapping
{
    public class UserMappingProfile : Profile
    {
		public UserMappingProfile()
		{
			CreateMap<UserModel, AuthentificationDTO>().ReverseMap();
		}
	}
}
