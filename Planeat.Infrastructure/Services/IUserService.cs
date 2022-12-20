﻿using Planeat.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetAsync(string email);
        Task RegisterAsync(string email, string firstName, string lastName, string password);
        Task LoginAsync(string email, string password);
    }
}
