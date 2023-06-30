using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AuthentificationDTO
    {
        public int IdUser { get; set; }
        public string Role { get; set; } = null!;
    }
}
