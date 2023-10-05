using WebApplication1.Models;

namespace WebApplication1.Responses
{
    public class ResponseProyecto
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public object Data { get; set; }
    }

    public class ProyectosResponse : ResponseProyecto
    {
        public List<FpProyecto> Data { get; set; }
    }

    public class ProyectoResponse : ResponseProyecto
    {
        public FpProyecto Data { get; set; }
    }
}
