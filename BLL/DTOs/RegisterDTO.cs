using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
	public class RegisterDTO
	{
		public int IdUser { get; set; }

		public string Name { get; set; } = null!;

		public string Surname { get; set; } = null!;

		public string? Patronymic { get; set; }

		public string? Email { get; set; }

		public string? Profileimage { get; set; }

		public int IdAuthorize { get; set; }

		public string Login { get; set; } = null!;

		public string Password { get; set; } = null!;

		public string Type { get; set; } = null!;
	}
}
