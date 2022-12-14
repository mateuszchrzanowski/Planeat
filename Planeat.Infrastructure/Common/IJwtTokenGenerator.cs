using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Common
{
    public interface IJwtTokenGenerator : ICommon
    {
        string GenerateToken(Guid userId, string firstName, string lastName, string role);
    }
}
