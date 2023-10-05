using WebApplication1.Models;

namespace WebApplication1.Responses
{
    public class ResponseTarea
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public object Data { get; set; }
    }

    public class TareasResponse : ResponseTarea
    {
        public List<FpTarea> Data { get; set; }    
    }

    public class TareaResponse : ResponseTarea
    {
        public FpTarea Data { get; set; }
    }
}
