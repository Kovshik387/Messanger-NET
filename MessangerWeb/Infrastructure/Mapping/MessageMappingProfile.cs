using AutoMapper;
using BLL.DTOs;
using MessangerWeb.Models;

namespace MessangerWeb.Infrastructure.Mapping
{
	public class MessageMappingProfile : Profile
	{
		public MessageMappingProfile() 
		{
			CreateMap<MessageDTO,MessageView>().ReverseMap();
		}
	}
}
