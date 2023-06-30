using BLL.DTOs;
using BLL.Infrastructure.Mapping;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;

namespace BLL.Services
{
	public class RegistrationService : IRegistrationService
	{
		private readonly IUnitOfWork _dbContext;
		
		public RegistrationService(IUnitOfWork dbContext) => _dbContext = dbContext;
		
		public async Task<RegisterDTO?> AddUserAsync(RegisterDTO modelDTO)
		{
			var account = Mapping.Mapper.Map<Authorize>(modelDTO);

			var profile = await _dbContext.RoleRepository.GetRoleAsync(modelDTO.Type); ;
			if (profile == null) throw new Exception("Ошибка, данной роли не существует");
			
			account.IdRoleNavigation = profile!; account.IdRole = profile.IdRole;

			var user = Mapping.Mapper.Map<User>(modelDTO);

			user.IdAuthorizeNavigation = account;
			account.User = user;

			await _dbContext.UserRepository.CreateAsync(user);
			await _dbContext.SaveChangesAsync();
			return modelDTO;
		}
	}
}
