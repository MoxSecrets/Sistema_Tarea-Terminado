using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController
    {
        ProyectoService service = new();

        [HttpGet("lista-proyecto")]
        public async Task<IActionResult> ListaProyectos()
        {
            var response = await service.ListaProyectos();
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpPost("crear-proyecto")]
        public async Task<IActionResult> CrearProyecto([FromBody] ProyectoDTO data)
        {
            var fpProyecto = new FpProyecto
            {
                ProNombre = data.ProNombre,
                ProDescripcion = data.ProDescripcion,
                ProFechaInicio = data.ProFechaInicio,
                ProFechaFinalizacion = data.ProFechaFinalizacion,
                ProTareaId = data.ProTareaId,
            };

            var response = await service.CrearProyecto(fpProyecto);
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpPut("editar-proyecto/{proyectoId}")]
        public async Task<IActionResult> EditarProyecto([FromBody] ProyectoUpdateDTO data, int proyectoId)
        {
            var response = await service.EditarProyecto(data, proyectoId);
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpDelete("eliminar-proyecto/{proyectoId}")]
        public async Task<IActionResult> EliminarProyecto(int proyectoId)
        {
            var response = await service.EliminarProyecto(proyectoId);
            return new JsonResult(response) { StatusCode = response.Code };
        }
    }
}
