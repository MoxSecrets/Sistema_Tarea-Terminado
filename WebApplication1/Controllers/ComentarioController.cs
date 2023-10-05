using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/v1/comentarios")]
    [ApiController]
    public class ComentarioController
    {
        ComentarioService service = new();

        [HttpGet("lista-comentario")]
        public async Task<IActionResult> ListaComentarios()
        {
            var response = await service.ListaComentarios();
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpPost("crear-comentario")]
        public async Task<IActionResult> CrearComentario([FromBody] ComentarioDTO data)
        {
            var response = await service.CrearComentario(data);
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpPut("editar-comentario/{comentarioId}")]
        public async Task<IActionResult> EditarComentario([FromBody] ComentarioUpdateDTO data, int comentarioId)
        {
            var response = await service.EditarComentario(data, comentarioId);
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpDelete("eliminar-comentario/{comentarioId}")]
        public async Task<IActionResult> EliminarComentario(int comentarioId)
        {
            var response = await service.EliminarComentario(comentarioId);
            return new JsonResult(response) { StatusCode = response.Code };
        }
    }
}
