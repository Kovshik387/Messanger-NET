﻿using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IRegistrationService
	{
		public Task<RegisterDTO?> AddUserAsync(RegisterDTO registerDTO);

		public Task<List<RoleDTO?>> GetAllRoleAsync();
	}
}
