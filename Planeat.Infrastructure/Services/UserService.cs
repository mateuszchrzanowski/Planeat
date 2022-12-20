using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Planeat.Core.Domain;
using Planeat.Core.Repositories;
using Planeat.Infrastructure.Commands.Users;
using Planeat.Infrastructure.Common;
using Planeat.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public UserService(IUserRepository userRepository,
            IMapper mapper, IPasswordHasher<User> passwordHasher, 
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            IEnumerable<User> users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetAsync(string email)
        {
            User user = await _userRepository.GetAsync(email);

            return _mapper.Map<User, UserDto>(user);
        }

        public async Task LoginAsync(string email, string password)
        {
            User user = await _userRepository.GetAsync(email);

            if (user == null)
            {
                throw new Exception("Invalid credentials.");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);

            if (result == PasswordVerificationResult.Failed)
            {
                throw new Exception("Invalid credentials.");
            }
        }

        public async Task RegisterAsync(
            string email, string firstName, string lastName, string password)
        {
            User user = await _userRepository.GetAsync(email);

            if (user != null)
            {
                throw new Exception($"User with email: '{email}' already exist.");
            }

            var hashedPassword = _passwordHasher.HashPassword(null, password);
            user = new User(email, hashedPassword, firstName, lastName);
            await _userRepository.AddAsync(user);
        }
    }
}
