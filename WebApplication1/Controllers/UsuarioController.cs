using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/v1/usuarios-controller")] //define la ruta de la API
    [ApiController] //define que es un controlador de API
    public class UsuarioController
    {
        UsuariosService service = new();

        [HttpGet("lista-usuario")]
        public async Task<IActionResult> ListaUsuarios()
        {
            var response = await service.ListaUsuarios();
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpPost("crear-usuario")]
        public async Task<IActionResult> CrearUsuario([FromBody] UsuarioDTO data)
        {
            var response = await service.CrearUsuario(data);
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpPut("editar-usuario/{usuarioId}")]
        public async Task<IActionResult> EditarUsuario([FromBody] UsuariosUpdateDTO data, int usuarioId)
        {
            var response = await service.EditarUsuario(data, usuarioId);
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpDelete("eliminar-usuario/{usuarioId}")]
        public async Task<IActionResult> EliminarUsuario(int usuarioId)
        {
            var response = await service.EliminarUsuario(usuarioId);
            return new JsonResult(response) { StatusCode = response.Code };
        }

    }
}
