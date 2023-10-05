using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Detalle_ProyectoController
    {
        Detalle_ProyectoService service = new();

        [HttpGet("lista-detalle_proyectos")]
        public async Task<IActionResult> ListaDetalle_Proyectos()
        {
            var response = await service.ListaDetalleProyectos();
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpPost("crear-detalle_proyecto")]
        public async Task<IActionResult> CrearDetalle_Proyecto([FromBody] DetalleProyectoDTO data)
        {
            var response = await service.CrearDetalleProyecto(data);
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpPut("editar-detalle_proyecto/{detalleproyectoId}")]
        public async Task<IActionResult> EditarDetalle_Proyecto([FromBody] DetalleProyectoUpdateDTO data, int detalleProyectoId)
        {
            var response = await service.EditarDetalleProyecto(data, detalleProyectoId);
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpDelete("eliminar-detalle_proyecto/{detalleproyectoId}")]
        public async Task<IActionResult> EliminarDetalle_Proyecto(int detalleproyectoId)
        {
            var response = await service.EliminarDetalleProyecto(detalleproyectoId);
            return new JsonResult(response) { StatusCode = response.Code };
        }
    }
}
