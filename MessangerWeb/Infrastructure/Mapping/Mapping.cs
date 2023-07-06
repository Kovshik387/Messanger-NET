using AutoMapper;

namespace MessangerWeb.Infrastructure.Mapping
{
	public static class Mapping
	{
		private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
		{
			var config = new MapperConfiguration(cfg => {
				cfg.ShouldMapProperty = p => p.GetMethod!.IsPublic || p.GetMethod.IsAssembly;
				cfg.AddProfile<UserMappingProfile>();
				cfg.AddProfile<RegisterMappingProfile>();
				cfg.AddProfile<ChatMappingProfile>();
			});
			var mapper = config.CreateMapper();
			return mapper;
		});
		public static IMapper Mapper => Lazy.Value;
	}
}
