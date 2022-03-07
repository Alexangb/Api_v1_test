using Application.Api.Responses;
using Application.Core.Entitys;
using Application.Core.Interfaces;
using Application.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Threading.Tasks;

namespace Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolServices _rolServices;
        public RolController(IRolServices rolServices)
        {
            _rolServices = rolServices;
        }

        [HttpGet]
        public async Task<IActionResult> getAllRol()
        {
            var result = await _rolServices.GetAllRol();
            var response = new ApiResponse<IEnumerable>(result);
            return Ok(response);

        }
        //obtenemos solo un dato en espesifico
        [HttpGet("{id}")]
        public async Task<IActionResult> getRol(int id)
        {
            var result = await _rolServices.GetRol(id);
            var response = new ApiResponse<IEnumerable>(result);
            return Ok(response);

        }
        //creamos un nuevo usuario
        [HttpPost]
        public async Task<IActionResult> CreateRol(ERol erol)
        {


            await _rolServices.CreateRol(erol);
            var response = new ApiResponse<ERol>(erol);
            return Ok(response);


        }
        //editamos el usuario
        //[HttpPut]
        //public async Task<IActionResult> UpdateRol(ERol Erol,int id)
        //{
        //    var result = await _rolServices.UpdateRol(Erol);
        //    var response = new ApiResponse<bool>(result);
        //    return Ok(response);
        //}
        [HttpPut]
        public async Task<IActionResult> UpdateRol(ERol erol)
        {
            var result= await _rolServices.UpdateRol(erol);

            var response =new ApiResponse<bool>(result);
            return Ok(response);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var result = await _rolServices.DeleteRol(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);

        }

    }
}
