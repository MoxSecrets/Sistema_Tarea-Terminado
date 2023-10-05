using WebApplication1.Models;

namespace WebApplication1.Responses
{
    public class ResponseComentario
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public object Data { get; set; }
    }

    public class ComentariosResponse : ResponseComentario
    {
        public List<FpComentario> Data { get; set; }
    }

    public class ComentarioResponse : ResponseComentario
    {
        public FpComentario Data { get; set; }
    }
}
