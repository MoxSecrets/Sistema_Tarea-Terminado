using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Responses;

namespace WebApplication1.Services
{
    public class TareasService
    {
        public async Task<TareasResponse> ListaTareas()
        {
            TareasResponse response = new();
            using (var context = new sistema_tareaContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var tareas = (from t in context.FpTareas
                                      select t).ToList();

                        response.Data = tareas;
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

        public async Task<TareaResponse> CrearTarea(TareaDTO data)
        {
            TareaResponse response = new();
            using (var context = new sistema_tareaContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var tareaOcupada = (from t in context.FpTareas
                                            where t.TarNombre == data.TarNombre
                                            select t.TarNombre).FirstOrDefault();

                        if (tareaOcupada != null)
                        {
                            throw new Exception("Ya existe una tarea con ese nombre");
                        }

                        FpTarea tarea = new()
                        {
                            TarNombre = data.TarNombre,
                            TarDescripcion = data.TarDescripcion,
                            TarCompletada = data.TarCompletada,
                            TarFechaVencimiento = DateOnly.FromDateTime(DateTime.Now),
                            TarAsignacion = data.TarAsignacion
                        };

                        context.FpTareas.Add(tarea);
                        context.SaveChanges();

                        response.Data = tarea;
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

        public async Task<TareaResponse> EditarTarea(TareasUpdateDTO data, int tareaId)
        {
            TareaResponse response = new();
            using (var context = new sistema_tareaContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var tarea = (from t in context.FpTareas
                                     where t.TarId == tareaId
                                     select t).FirstOrDefault();

                        if (tarea != null)
                        {
                            if (!string.IsNullOrEmpty(data.TarNombre))
                            {
                                tarea.TarNombre = data.TarNombre;
                            }

                            if (!string.IsNullOrEmpty(data.TarDescripcion))
                            {
                                tarea.TarDescripcion = data.TarDescripcion;
                            }

                            context.SaveChanges();

                            response.Data = tarea;
                            response.Status = true;
                            response.Code = 200;
                            response.Message = "OK";
                        }
                        else
                        {
                            response.Status = false;
                            response.Code = 404;
                            response.Message = "No se encontró la tarea";
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

        public async Task<TareaResponse> EliminarTarea(int tareaId)
        {
            TareaResponse response = new();
            using (var context = new sistema_tareaContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var tarea = (from t in context.FpTareas
                                     where t.TarId == tareaId
                                     select t).FirstOrDefault();

                        if (tarea != null)
                        {
                            context.FpTareas.Remove(tarea);
                            context.SaveChanges();

                            response.Data = tarea;
                            response.Status = true;
                            response.Code = 200;
                            response.Message = "OK";
                        }
                        else
                        {
                            response.Status = false;
                            response.Code = 404;
                            response.Message = "No se encontró la tarea";
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
