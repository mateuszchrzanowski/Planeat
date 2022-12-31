using Planeat.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Commands.Users
{
    public class ChangeUserRole : ICommand
    {
        public Guid UserId { get; set; }
        public string RoleName { get; set; }
    }
}
