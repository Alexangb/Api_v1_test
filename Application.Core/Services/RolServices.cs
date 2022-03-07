using Application.Core.Entitys;
using Application.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Services
{
    public class RolServices : IRolServices
    {
        private readonly IRol _rolRepository;
        public RolServices(IRol rolrepository)
        {
            _rolRepository = rolrepository;
        }

        public async Task<bool> CreateRol(ERol eRol)
        {
            return await _rolRepository.CreateRol(eRol);
        }

        public async Task<bool> DeleteRol(int id)
        {
            return await _rolRepository.DeleteRol(id);
        }

        public async Task<IEnumerable<ERol>> GetAllRol()
        {
            return await _rolRepository.GetAllRol();
        }

        public async Task<IEnumerable<ERol>> GetRol(int id)
        {
            return await _rolRepository.GetRol(id);
        }

        public  async Task<bool> UpdateRol(ERol eRol)
        {
            return await _rolRepository.UpdateRol(eRol);
        }
    }
}
