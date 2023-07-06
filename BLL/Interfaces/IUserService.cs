using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        public Task<UserDTO> GetUserAsync(int id);

        public Task<UserDTO> GetAnotherUserAsync(int id_user, int id_chat);
        public Task<List<UserDTO>> GetAllUsersAsync();


    }
}
