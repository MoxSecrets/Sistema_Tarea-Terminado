using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Responses;

namespace WebApplication1.Services
{
    public class UsuariosService
    {
        // Indica el tipo de respuesta a retornar
        public async Task<UsuariosResponse> ListaUsuarios()
        {
            UsuariosResponse response = new();
            // Instancia de la conexion a la BD
            using (var context = new sistema_tareaContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        // Consulta sintaxis LinQ
                        var usuarios = (from u in context.FpUsuarios
                                       select u).ToList();

                        response.Data = usuarios;
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

        public async Task<UsuarioResponse> CrearUsuario(UsuarioDTO data)
        {
            UsuarioResponse response = new();
            using (var context = new sistema_tareaContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var nombreOcupado = (from u in context.FpUsuarios
                                             where u.UsuNombre == data.UsuNombre
                                             select u.UsuNombre).FirstOrDefault();

                        if (nombreOcupado != null)
                        {
                            throw new Exception("El nombre de usuario ya esta ocupado");
                        }

                        FpUsuario usuario = new()
                        {
                            UsuNombre = data.UsuNombre,
                            UsuCorreo = data.UsuCorreo,
                            UsuContrasena = data.UsuContrasena,
                        };

                        context.FpUsuarios.Add(usuario);
                        context.SaveChanges();

                        response.Data = usuario;
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

        public async Task<UsuarioResponse> EditarUsuario(UsuariosUpdateDTO data, int usuarioId)
        {
            UsuarioResponse response = new();
            using (var context = new sistema_tareaContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var usuario = (from u in context.FpUsuarios
                                       where u.UsuId == usuarioId
                                       select u).FirstOrDefault();

                        if (usuario != null)
                        {
                            if (!string.IsNullOrEmpty(data.NombreUsuario))
                            {
                                usuario.UsuNombre = data.NombreUsuario;
                            }

                            if (!string.IsNullOrEmpty(data.Contrasena))
                            {
                                usuario.UsuContrasena = data.Contrasena;
                            }

                            context.SaveChanges();

                            response.Data = usuario;
                            response.Status = true;
                            response.Code = 200;
                            response.Message = "OK";
                        }
                        else
                        {
                            response.Status = false;
                            response.Code = 404;
                            response.Message = "Usuario NO encontrado";
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

        public async Task<UsuarioResponse> EliminarUsuario(int usuarioId)
        {
            UsuarioResponse response = new();
            using (var context = new sistema_tareaContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var usuario = (from u in context.FpUsuarios
                                       where u.UsuId == usuarioId
                                       select u).FirstOrDefault();

                        if (usuario != null)
                        {
                            context.FpUsuarios.Remove(usuario);
                            context.SaveChanges();

                            response.Data = usuario;
                            response.Status = true;
                            response.Code = 200;
                            response.Message = "OK";
                        }
                        else
                        {
                            response.Status = false;
                            response.Code = 404;
                            response.Message = "Usuario NO encontrado";
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
