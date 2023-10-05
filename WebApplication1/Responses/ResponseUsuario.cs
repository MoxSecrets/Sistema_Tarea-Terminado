using WebApplication1.Models;

namespace WebApplication1.Responses
{
    public class ResponseUsuario
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public object Data { get; set; }
    }

    public class UsuariosResponse : ResponseUsuario
    {
        public List<FpUsuario> Data { get; set; }
    }

    public class UsuarioResponse : ResponseUsuario
    {
        public FpUsuario Data { get; set; }
    }
}
