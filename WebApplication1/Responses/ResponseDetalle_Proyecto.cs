using WebApplication1.Models;

namespace WebApplication1.Responses
{
    public class ResponseDetalle_Proyecto
    {
        public int Code { get; set; }
        public string Message { get; set; } 
        public bool Status { get; set; }
        public object Data { get; set; }
    }

    public class Detalle_ProyectosResponse : ResponseDetalle_Proyecto
    {
        public List<FpDetalleProyecto> Data { get; set; }
    }

    public class Detalle_ProyectoResponse : ResponseDetalle_Proyecto
    {
        public FpDetalleProyecto Data { get; set; }
    }
}
