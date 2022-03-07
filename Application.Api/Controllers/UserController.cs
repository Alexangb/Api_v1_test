using Application.Api.Responses;
using Application.Core.Entitys;
using Application.Core.Interfaces;
using Application.Core.QueryFilters;
using Application.Infraestructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using ServiceStack;
using ServiceStack.Text;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ValidationFilters]
    public class UserController : ControllerBase
    {
       
        private readonly IUserService _userService;

        /* creamos el contructor de postcontroller*/
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
       
         //obtenemos todos los datos
         /// <summary>
         /// MUESTRA TODOS LOS USUARIO
         /// </summary>
         /// <param name="pagina"></param>
         /// <param name="cantPag"></param>
         /// <param name="estado"></param>
         /// <returns></returns>
         [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> getAllUser(int? pagina, int? cantPag,string estado)
        {
           
         
            if (pagina==null&& cantPag == null)
            {
               
               var result = await _userService.GetAllUsers(estado);
                var response = new ApiResponse<IEnumerable>(result);
                return Ok(response);
            }
            else
            {
                var result = await _userService.GetAllUsersPaginado(pagina,cantPag,estado);
                var response = new ApiResponse<IEnumerable>(result);
                return Ok(response);
            }
           


        }
        //obtenemos solo un dato en espesifico
        /// <summary>
        ///  Devuelve un usuario  espesifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]

        public async Task<IActionResult> getUser(int id)
        {
            var result = await _userService.GetUser(id);
            var response = new ApiResponse<IEnumerable>(result);
            return Ok(response);

        }
        //obtenemos usuario por fltrado de palabras
        //[HttpGet("{letra}")]
        //public async Task<IActionResult> getUserSearch(string letra)
        //{
        //    var result = await _userService.GetUserBySearch(letra);
        //    var response = new ApiResponse<IEnumerable>(result);
        //    return Ok(response);

        //}
        //creamos un nuevo usuario
        /// <summary>
        /// Crea un nuevo usuario
        /// </summary>
        /// <param name="eUser"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult>CreateUser(EUser eUser)
        {
           
           
            await _userService.CreateUSer(eUser);
            var response = new ApiResponse<EUser>(eUser);
            return Ok(response);
           
           
        }
        //editamos el usuario
        /// <summary>
        /// Edita un nuevo Usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        
        public async Task<IActionResult>UpdateUser(EUser user)
        {
          var result=  await _userService.UpdateUSer(user);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }


        /// <summary>
        /// Elimina un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            //if (opcion == 0)
            //{

            //    var result = await _userService.DeleteUser(id, opcion);
            //    var response = new ApiResponse<bool>(result);
            //    return Ok(response);
            //}
            //else 
            //{
                var result = await _userService.DeleteUserL(id);
                var response = new ApiResponse<bool>(result);
                return Ok(response);
            //}
           


        }




    }
}
