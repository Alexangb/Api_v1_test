using Application.Core.Entitys;
using Application.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<EUser>> GetAllUsers(string estado);
        Task<IEnumerable<EUser>> GetAllUsersPaginado(int? pagina_inicio, int? pagina_final, string estado);
        Task<IEnumerable<EUser>> GetUser(int id);

        Task<IEnumerable<EUser>> GetUserBySearch(string palabra);


        Task<bool> CreateUSer(EUser eUser);
        Task<bool> UpdateUSer(EUser eUser);

        Task<bool> DeleteUserL(int id/*, int opcion*/);
        Task<bool> DeleteUser(int id/*, int opcion*/);
        //Task<bool> DeleteUser(int id);
    }
}
