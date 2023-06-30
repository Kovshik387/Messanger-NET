using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAuthentificationService
    {
        public Task<AuthentificationDTO?> GetUserAsync(string login, string password);
    }
}
