using AutoMapper;
using BLL.DTOs;
using DAL.Models;

namespace BLL.Infrastructure.Mapping
{
	public class ChatMappingProfile : Profile
	{
		public ChatMappingProfile()
		{
			CreateMap<Chat, ChatDTO>().ReverseMap();
			CreateMap<Message, MessageDTO>().ReverseMap();
			CreateMap<Userschat, ChatUserDTO>().ReverseMap();
			CreateMap<User,UserDTO>().ReverseMap();
		}
		
	}
}
