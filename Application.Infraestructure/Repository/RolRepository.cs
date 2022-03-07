using Application.Core.Entitys;
using Application.Core.Interfaces;
using Application.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infraestructure.Repository
{
    public class RolRepository : IRol
    {
        public async Task<bool> CreateRol(ERol eRol)
        {
            var rol = new DRol();
            var usu = await rol.Crear(eRol);
            return usu;
        }

        public async Task<bool> DeleteRol(int id)
        {
            var rol = new DRol();
            var usu = await rol.Eliminar(id);
            return usu;
        }

        public async Task<IEnumerable<ERol>> GetAllRol()
        {
            var rol = new DRol();
            var usu = await rol.ListarRol();
            return usu;
        }

        public async Task<IEnumerable<ERol>> GetRol(int id)
        {
            var rol = new DRol();
            var usu = await rol.GetRolID(id);
            return usu;
        }

        public async Task<IEnumerable<ERol>> GetRolBySearch(int id)
        {
            var rol = new DRol();
            var usu = await rol.GetRolID(id);
            return usu;
        }

        public async Task<bool> UpdateRol(ERol eRol)
        {
            var rol = new DRol();
            var usu = await rol.Editar(eRol);
            return usu; 
        }
    }
}
