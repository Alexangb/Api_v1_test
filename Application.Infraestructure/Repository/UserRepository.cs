using Application.Core.Entitys;
using Application.Core.Interfaces;
using Application.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infraestructure.Repository
{
    public class UserRepository : IPostRepository
    {
        public async Task<bool>  CreateUSer(EUser eUser)
        {
            var user = new DUser();
            var usu =await user.Crear(eUser);
            return usu;
        }

        public async Task<bool> DeleteUser(int id/*,int opcion*/)
        {
            var user = new DUser();
            var usu = await user.Eliminar(id);
            return usu;
        }

        public async Task<bool> DeleteUserL(int id/*,int opcion*/)
        {
            var user = new DUser();
            var usu = await user.EliminarL(id);
            return usu;
        }

        public async Task<IEnumerable<EUser>> GetAllUsers(string estado)
        {
            var user = new DUser();
            var usu = await user.ListarUsuario(estado);
            return usu;
        }

        public async Task<IEnumerable<EUser>> GetAllUsersPaginado(int? pagina_inicio, int? pagina_final, string estado)
        {
            var user = new DUser();
            var usu = await user.PaginarUsuarios(pagina_inicio,pagina_final,estado);
            return usu;
        }

        public async Task<IEnumerable<EUser>> GetUser(int id)
        {
            var user = new DUser();
            var usu = await user.GetUserID(id);
            return usu;
        }

        public async Task<IEnumerable<EUser>> GetUserBySearch(string palabra)
        {
            var user = new DUser();
            var usu = await user.ObtenerUsuarioPalabra(palabra);
            return usu;
        }

        public async Task <bool> UpdateUSer(EUser eUser)
        {
            var user = new DUser();
            var usu = await user.Editar(eUser);
            return usu;
        }
    }
}
