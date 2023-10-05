using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class FpProyecto
    {
        public FpProyecto()
        {
            FpDetalleProyectos = new HashSet<FpDetalleProyecto>();
        }

        public int ProId { get; set; }
        public string ProNombre { get; set; } = null!;
        public string ProDescripcion { get; set; } = null!;
        public DateOnly ProFechaInicio { get; set; }
        public DateOnly ProFechaFinalizacion { get; set; }
        public int ProTareaId { get; set; }

        public virtual FpTarea ProTarea { get; set; } = null!;
        public virtual ICollection<FpDetalleProyecto> FpDetalleProyectos { get; set; }
    }
}
