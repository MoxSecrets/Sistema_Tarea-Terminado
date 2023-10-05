using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Responses;

namespace WebApplication1.Services
{
    public class ProyectoService
    {
        public async Task<ProyectosResponse> ListaProyectos()
        {
            ProyectosResponse response = new();
            using (var context = new sistema_tareaContext())
            {
                try
                {
                    await Task.Run (() =>
                    {
                        var proyectos = (from p in context.FpProyectos
                                         select p).ToList();

                        response.Data = proyectos;
                        response.Status = true;
                        response.Code = 200;
                        response.Message = "OK";
                    });
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                    response.Status = false;
                    response.Code = 500;
                }
            }
            return response;
        }

        public async Task<ProyectoResponse> CrearProyecto(FpProyecto data)
        {
            ProyectoResponse response = new();
            using (var context = new sistema_tareaContext())
            {
                try
                {
                    await Task.Run (() =>
                    {
                        var proyectoOcupado = (from p in context.FpProyectos
                                               where p.ProNombre == data.ProNombre
                                               select p.ProNombre).FirstOrDefault();

                        if (proyectoOcupado != null)
                        {
                            throw new Exception("Ya existe un proyecto con ese nombre");
                        }

                        FpProyecto proyecto = new()
                        {
                            ProNombre = data.ProNombre,
                            ProDescripcion = data.ProDescripcion,
                            ProFechaInicio = DateOnly.FromDateTime(DateTime.Now),
                            ProFechaFinalizacion = DateOnly.FromDateTime(DateTime.Now),
                            ProTareaId = data.ProTareaId,
                        };

                        context.FpProyectos.Add(proyecto);
                        context.SaveChanges();

                        response.Data = proyecto;
                        response.Status = true;
                        response.Code = 200;
                        response.Message = "OK";
                    });
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                    response.Status = false;
                    response.Code = 500;
                }
            }
            return response;
        }

        public async Task<ProyectoResponse> EditarProyecto(ProyectoUpdateDTO data, int proyectoId)
        {
            ProyectoResponse response = new();
            using (var context = new sistema_tareaContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var proyecto = context.FpProyectos.FirstOrDefault(p => p.ProId == proyectoId);

                        if (proyecto != null)
                        {
                            if (!string.IsNullOrEmpty(data.ProNombre))
                            {
                                proyecto.ProNombre = data.ProNombre;
                            }

                            if (!string.IsNullOrEmpty(data.ProDescripcion))
                            {
                                proyecto.ProDescripcion = data.ProDescripcion;
                            }

                            context.SaveChanges();

                            response.Data = proyecto;
                            response.Status = true;
                            response.Code = 200;
                            response.Message = "Proyecto editado exitosamente.";

                        }
                        else
                        {
                            response.Status = false;
                            response.Code = 404;
                            response.Message = "Proyecto NO encontrado";
                        }
                    });
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Code = 500;
                    response.Message = "Error: " + ex.Message;
                }
            }
            return response;
        }

        public async Task<ProyectoResponse> EliminarProyecto(int proyectoId)
        {
            ProyectoResponse response = new();
            using (var context = new sistema_tareaContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var proyecto = (from p in context.FpProyectos
                                        where p.ProId == p.ProId
                                        select p).FirstOrDefault();

                        if (proyecto != null)
                        {
                            context.FpProyectos.Remove(proyecto);
                            context.SaveChanges();

                            response.Data = proyecto;
                            response.Status = true;
                            response.Code = 200;
                            response.Message = "Proyecto eliminado exitosamente.";
                        }
                        else
                        {
                            response.Status = false;
                            response.Code = 404;
                            response.Message = "Proyecto NO encontrado.";
                        }
                    });
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Code = 500;
                    response.Message = "Error: " + ex.Message;
                }
            }
            return response;
        }
    }
}
