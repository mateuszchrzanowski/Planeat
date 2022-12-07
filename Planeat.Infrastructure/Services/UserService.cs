using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Planeat.Core.Domain;
using Planeat.Core.Repositories;
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

        public UserService(IUserRepository userRepository, 
            IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
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

            _passwordHasher.VerifyHashedPassword(user, user.Password, password);

            if (true)
            {
                return;
            }

            throw new Exception("Invalid credentials.");
        }

        public async Task RegisterAsync(
            string email, string username, string password, int roleId)
        {
            User user = await _userRepository.GetAsync(email);

            if (user != null)
            {
                throw new Exception($"User with email: {email} already exist.");
            }

            var hashedPassword = _passwordHasher.HashPassword(null, password);
            //var salt = _encrypter.GetSalt(password);
            //var hash = _encrypter.GetHash(password, salt);
            user = new User(email, username, hashedPassword, roleId);
            await _userRepository.AddAsync(user);
        }
    }
}
