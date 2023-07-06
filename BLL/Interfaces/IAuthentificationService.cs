using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IAuthentificationService
    {
        public Task<AuthentificationDTO?> GetUserAsync(string login, string password);

        public Task<UserDTO> GetUserProfileImage(int id_user);
    }
}
