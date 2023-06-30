using AutoMapper;
using BLL.DTOs;
using DAL.Models;

namespace BLL.Infrastructure.Mapping
{
	public class RegisterMappingProfile : Profile
	{
		public RegisterMappingProfile()
		{
			CreateMap<Authorize, RegisterDTO>().ReverseMap();
			CreateMap<User,RegisterDTO>().ReverseMap();
		}
	}
}
