using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class FpComentario
    {
        public int ComId { get; set; }
        public string ComContenido { get; set; } = null!;
        public DateOnly ComFechaCreacion { get; set; }
        public int ComTareaId { get; set; }

        public virtual FpTarea ComTarea { get; set; } = null!;
    }
}
