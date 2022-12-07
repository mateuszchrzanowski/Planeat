using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Commands.Users
{
    public class CreateUser : ICommand
    {
        [Required]
        public string Email { get; set; }
        public string Username { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        public int RoleId { get; set; } = 1;

    }
}
