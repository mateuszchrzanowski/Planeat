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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleDto>> GetAllAsync()
        {
            IEnumerable<Role> roles = await _roleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Role>, IEnumerable<RoleDto>>(roles);
        }

        //public async Task<RoleDto> GetAsync(int id)
        //{
        //    Role role = await _roleRepository.GetAsync(id);

        //    return _mapper.Map<Role, RoleDto>(role);
        //}

        public async Task<RoleDto> GetAsync(string name)
        {
            Role role = await _roleRepository.GetAsync(name);

            return _mapper.Map<Role, RoleDto>(role);
        }

        public async Task CreateAsync(string name)
        {
            Role role = await _roleRepository.GetAsync(name);

            if (role != null)
            {
                throw new Exception("Role with given name already exist.");
            }

            role = new Role(name);
            await _roleRepository.AddAsync(role);
        }
    }
}
