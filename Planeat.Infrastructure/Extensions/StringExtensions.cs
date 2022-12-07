using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static bool Empty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}
