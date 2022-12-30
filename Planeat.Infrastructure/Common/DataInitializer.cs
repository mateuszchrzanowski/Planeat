using Microsoft.Extensions.Logging;
using Planeat.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Common
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private readonly ILogger<DataInitializer> _logger;

        public DataInitializer(IUserService userService, ILogger<DataInitializer> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            _logger.LogTrace("Initializing data...");

            var tasks = new List<Task>();
            //CreateTestUsers(tasks, "user", 10);
            //CreateTestUsers(tasks, "admin", 10);

            for (int i = 1; i <= 10; i++)
            {
                var name = $"User{i}";
                var email = $"{name}@test.com";
                var password = $"VerySecret{i}";
                tasks.Add(_userService.RegisterAsync(email, name, name, password, "User"));
                _logger.LogTrace($"Created new user: '{email}'.");
            }

            for (int i = 1; i <= 3; i++)
            {
                var name = $"Admin{i}";
                var email = $"{name}@test.com";
                var password = $"VerySecret{i}";
                tasks.Add(_userService.RegisterAsync(email, name, name, password, "Admin"));
                _logger.LogTrace($"Created new admin: '{email}'.");
            }

            await Task.WhenAll(tasks);
            _logger.LogTrace("Data was initialized.");
        }

        //private async void CreateTestUsers(List<Task> tasks, string userName, int numberOfUsers)
        //{
        //    for (int i = 1; i <= numberOfUsers; i++)
        //    {
        //        var email = $"{userName}@test.com";
        //        var password = $"VerySecret{i}";
        //        tasks.Add(_userService.RegisterAsync(email, userName, userName, password));
        //    }

        //    await Task.WhenAll(tasks);
        //}
    }
}
