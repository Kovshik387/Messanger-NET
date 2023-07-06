using AutoMapper;
using BLL.DTOs;
using BLL.Infrastructure.Mapping;
using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<UserDTO> GetAnotherUserAsync(int id_user, int id_chat) => Mapping.Mapper.Map<UserDTO>(await _unitOfWork.UserRepository.GetAnotherUserAsync(id_user, id_chat));

        public async Task<UserDTO> GetUserAsync(int id) => Mapping.Mapper.Map<UserDTO>(await _unitOfWork.UserRepository.GetItemAsync(id));

        public async Task<List<UserDTO>> GetAllUsersAsync() => Mapping.Mapper.Map<List<UserDTO>>(await _unitOfWork.UserRepository.GetAllAsync());
    }
}
