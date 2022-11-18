using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Extensions
{
    public static class SettingsExtensions
    {
        public static T GetSettings<T>(this IConfiguration configuraiton) where T : new()
        {
            var section = typeof(T).Name.Replace("Settings", String.Empty);
            var configurationValue = new T();
            configuraiton.GetSection(section).Bind(configurationValue);

            return configurationValue;
        }
    }
}
