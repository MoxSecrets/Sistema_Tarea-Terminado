using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Responses;

namespace WebApplication1.Services
{
    public class Detalle_ProyectoService
    {
        public async Task<Detalle_ProyectosResponse> ListaDetalleProyectos()
        {
            Detalle_ProyectosResponse response = new();
            using (var context = new sistema_tareaContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var detalleProyectos = (from dp in context.FpDetalleProyectos
                                                select dp).ToList();

                        response.Data = detalleProyectos;
                        response.Status = true;
                        response.Code = 200;
                        response.Message = "OK";
                    });
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Code = 400;
                    response.Message = "Error: " + ex.Message;
                }
            }
            return response;
        }

        public async Task<Detalle_ProyectoResponse> CrearDetalleProyecto(DetalleProyectoDTO data)
        {
            Detalle_ProyectoResponse response = new();
            using ( var context = new sistema_tareaContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        FpDetalleProyecto detalle_Proyecto = new()
                        {
                            DproFechaIntegracion = DateOnly.FromDateTime(DateTime.Now),
                            DproProyecto = data.DproProyecto,
                            DproUsuario = data.DproUsuario
                        };

                        context.FpDetalleProyectos.Add(detalle_Proyecto);
                        context.SaveChanges();

                        response.Data = detalle_Proyecto;
                        response.Status = true;
                        response.Code = 200;
                        response.Message = "OK";
                    });
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Code = 400;
                    response.Message = "Error: " + ex.Message;
                }
            }
            return response;
        }

        public async Task<Detalle_ProyectoResponse> EditarDetalleProyecto(DetalleProyectoUpdateDTO data, int id)
        {
            Detalle_ProyectoResponse response = new();
            using (var context = new sistema_tareaContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var detalleProyecto = (from dp in context.FpDetalleProyectos
                                               where dp.DproId == id
                                               select dp).FirstOrDefault();

                        if (detalleProyecto != null)
                        {
                            if (data.DproFechaIntegracion.HasValue)
                            {
                                detalleProyecto.DproFechaIntegracion = data.DproFechaIntegracion.Value;
                            }

                            if (data.DproProyecto.HasValue)
                            {
                                detalleProyecto.DproProyecto = data.DproProyecto.Value;
                            }

                            if (data.DproUsuario.HasValue)
                            {
                                detalleProyecto.DproUsuario = data.DproUsuario.Value;
                            }

                            context.SaveChanges();

                            response.Data = detalleProyecto;
                            response.Status = true;
                            response.Code = 200;
                            response.Message = "OK";
                        }
                        else
                        {
                            response.Status = false;
                            response.Code = 404;
                            response.Message = "Detalle de proyecto NO encontrado";
                        }
                    });
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Code = 400;
                    response.Message = "Error: " + ex.Message;
                }
            }
            return response;
        }

        public async Task<Detalle_ProyectoResponse> EliminarDetalleProyecto(int detalleProyectoId)
        {
            Detalle_ProyectoResponse response = new();
            using (var context = new sistema_tareaContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var detalleProyecto = (from dp in context.FpDetalleProyectos
                                               where dp.DproId == detalleProyectoId
                                               select dp).FirstOrDefault();

                        if (detalleProyecto != null)
                        {
                            context.FpDetalleProyectos.Remove(detalleProyecto);
                            context.SaveChanges();

                            response.Data = detalleProyecto;
                            response.Status = true;
                            response.Code = 200;
                            response.Message = "OK";
                        }
                        else
                        {
                            response.Status = false;
                            response.Code = 404;
                            response.Message = "Detalle de proyecto NO encontrado";
                        }
                    });
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Code = 400;
                    response.Message = "Error: " + ex.Message;
                }
            }
            return response;
        }
    }
}
