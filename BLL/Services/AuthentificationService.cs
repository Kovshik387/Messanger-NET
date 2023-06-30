using AutoMapper;
using BLL.DTOs;
using BLL.Infrastructure.Mapping;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using System.Net;

namespace BLL.Services
{
    public class AuthentificationService : IAuthentificationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthentificationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AuthentificationDTO?> GetUserAsync(string login, string password)        
        {
			return Mapping.Mapper.Map<AuthentificationDTO>(await _unitOfWork.UserRepository.GetUserByLoginAsync(login, password));
        }

    }
}
