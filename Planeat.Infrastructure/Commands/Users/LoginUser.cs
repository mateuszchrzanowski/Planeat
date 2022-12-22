using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Commands.Users
{
    public class LoginUser : ICommand
    {
        public Guid JwtTokenId { get; protected set; } = Guid.NewGuid();
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
