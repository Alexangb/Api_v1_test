using Application.Core.Entitys;
using Application.Core.Interfaces;
using Application.Core.QueryFilters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Services
{
    public class UserServices: IUserService
    {
        private readonly IPostRepository _postRepository;
        public UserServices( IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        //[HttpPost]
      

        public async Task<bool> CreateUSer(EUser eUser)
        {
          return  await _postRepository.CreateUSer(eUser);
        }

        public async Task<bool> DeleteUser(int id/*,int opcion*/)
        {
            return await _postRepository.DeleteUser( id/*, opcion*/);
        }

        public async Task<bool> DeleteUserL(int id/*, int opcion*/)
        {
            return await _postRepository.DeleteUserL(id/*,opcion*/);
        }

        public async Task<IEnumerable<EUser>> GetAllUsers(string estado)
        {
            return await _postRepository.GetAllUsers( estado);
        }

        public async Task<IEnumerable<EUser>> GetAllUsersPaginado(int? pagina_inicio, int? pagina_final, string estado)
        {
            return await _postRepository.GetAllUsersPaginado(pagina_inicio,pagina_final,estado);
        }

        public async Task<IEnumerable<EUser>> GetUser(int id)
        {
            return await _postRepository.GetUser(id);
        }

        public async Task<IEnumerable<EUser>> GetUserBySearch(string palabra)
        {
            return await _postRepository.GetUserBySearch(palabra);
        }

        public async Task<bool> UpdateUSer(EUser eUser)
        {
            return await _postRepository.UpdateUSer(eUser);
        }
    }
}
