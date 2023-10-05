using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Responses;

namespace WebApplication1.Services
{
    public class ComentarioService
    {
        public async Task<ComentariosResponse> ListaComentarios()
        {
            ComentariosResponse response = new();
            using (var context = new sistema_tareaContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var comentarios = (from c in context.FpComentarios
                                           select c).ToList();

                        response.Data = comentarios;
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

        public async Task<ComentarioResponse> CrearComentario(ComentarioDTO data)
        {
            ComentarioResponse response = new();
            using (var context = new sistema_tareaContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var comentarioOcupado = (from c in context.FpComentarios
                                                 where c.ComContenido == data.ComContenido
                                                 select c.ComContenido).FirstOrDefault();
                        if (comentarioOcupado != null)
                        {
                            throw new Exception("Ya existe un comentario con ese contenido");
                        }

                        FpComentario comentario = new()
                        {
                            ComContenido = data.ComContenido,
                            ComFechaCreacion = DateOnly.FromDateTime(DateTime.Now),
                            ComTareaId = data.ComTareaId
                        };

                        context.FpComentarios.Add(comentario);
                        context.SaveChanges();

                        response.Data = comentario;
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

        public async Task<ComentarioResponse> EditarComentario(ComentarioUpdateDTO data, int comentarioId)
        {
            ComentarioResponse response = new();
            using (var context = new sistema_tareaContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var comentario = (from c in context.FpComentarios
                                          where c.ComId == comentarioId
                                          select c).FirstOrDefault();

                        if (comentario != null)
                        {
                            if (!string.IsNullOrEmpty(data.ComContenido))
                            {
                                comentario.ComContenido = data.ComContenido;
                            }

                            if (data.ComFechaCreacion.HasValue)
                            {
                                comentario.ComFechaCreacion = data.ComFechaCreacion.Value;
                            }

                            if (data.ComTarea != null)
                            {
                                comentario.ComTarea = data.ComTarea;
                            }

                            context.SaveChanges();

                            response.Data = comentario;
                            response.Status = true;
                            response.Code = 200;
                            response.Message = "OK";
                        }
                        else
                        {
                            response.Status = false;
                            response.Code = 404;
                            response.Message = "Comentario NO encontrado";
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

        public async Task<ComentarioResponse> EliminarComentario(int comentarioId)
        {
            ComentarioResponse response = new();
            using (var context = new sistema_tareaContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var comentario = (from c in context.FpComentarios
                                          where c.ComId == comentarioId
                                          select c).FirstOrDefault();

                        if (comentario != null)
                        {
                            context.FpComentarios.Remove(comentario);
                            context.SaveChanges();

                            response.Data = comentario;
                            response.Status = true;
                            response.Code = 200;
                            response.Message = "OK";
                        }
                        else
                        {
                            response.Status = false;
                            response.Code = 404;
                            response.Message = "Comentario NO encontrado";
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
