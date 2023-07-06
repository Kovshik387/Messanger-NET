using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
	public class UserDTO
	{
		public int IdUser { get; set; }

		public string Name { get; set; } = null!;

		public string Surname { get; set; } = null!;

		public string? Patronymic { get; set; }

		public string? Profileimage { get; set; }
		public string? Role { get; set; }
	}
}
