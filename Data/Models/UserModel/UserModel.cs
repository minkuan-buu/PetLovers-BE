using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.UserModel
{
    public class UserModel
    {
        public string Name { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public Guid RoleId { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreateAt { get; set; }
    }
}
