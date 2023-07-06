using AutoMapper;
using BLL.DTOs;
using MessangerWeb.Models;

namespace MessangerWeb.Infrastructure.Mapping
{
	public class ChatMappingProfile : Profile
	{
		public ChatMappingProfile() 
		{
			CreateMap<ChatDTO,ChatView>().ReverseMap();
			CreateMap<MessageDTO, MessageView>().ReverseMap();
			CreateMap<ChatUserDTO, UserchatView>().ReverseMap();
		}
	}
}
