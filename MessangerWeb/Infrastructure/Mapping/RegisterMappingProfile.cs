using AutoMapper;
using BLL.DTOs;
using MessangerWeb.Models;

namespace MessangerWeb.Infrastructure.Mapping
{
	public class RegisterMappingProfile : Profile
	{
		public RegisterMappingProfile()
		{
			CreateMap<RegisterView, RegisterDTO>().ReverseMap();
		}
	}
}
