using AutoMapper;
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

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserDto Get(string email)
        {
            User user = _userRepository.Get(email);

            if (user == null)
            {
                throw new Exception($"User with email: {email} doesn't exist.");
            }

            return _mapper.Map<User, UserDto>(user);
        }

        public void Register(string email, string username, string password)
        {
            User user = _userRepository.Get(email);

            if (user != null)
            {
                throw new Exception($"User with email: {email} already exist.");
            }

            var salt = Guid.NewGuid().ToString("N");
            user = new User(email, username, password, salt);
            _userRepository.Add(user);
        }
    }
}
