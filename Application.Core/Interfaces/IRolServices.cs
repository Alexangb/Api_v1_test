using Application.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Interfaces
{
    public interface IRolServices
    {
        Task<IEnumerable<ERol>> GetAllRol();
        Task<IEnumerable<ERol>> GetRol(int id);

        //Task<IEnumerable<ERol>> GetRolBySearch(string palabra);


        Task<bool> CreateRol(ERol eRol);
        Task<bool> UpdateRol(ERol eRol);

        Task<bool> DeleteRol(int id);
    }
}
