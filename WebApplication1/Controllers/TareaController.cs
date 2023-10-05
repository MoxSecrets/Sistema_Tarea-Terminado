using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController
    {
        TareasService service = new();

        [HttpGet("lista-tarea")]
        public async Task<IActionResult> ListaTareas()
        {
            var response = await service.ListaTareas();
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpPost("crear-tarea")]
        public async Task<IActionResult> CrearTarea([FromBody] TareaDTO data)
        {
            var response = await service.CrearTarea(data);
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpPut("editar-tarea/{tareaId}")]
        public async Task<IActionResult> EditarTarea([FromBody] TareasUpdateDTO data, int tareaId)
        {
            var response = await service.EditarTarea(data, tareaId);
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpDelete("eliminar-tarea/{tareaId}")]
        public async Task<IActionResult> EliminarTarea(int tareaId)
        {
            var response = await service.EliminarTarea(tareaId);
            return new JsonResult(response) { StatusCode = response.Code };
        }
    }
}
