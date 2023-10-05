using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class FpTarea
    {
        public FpTarea()
        {
            FpComentarios = new HashSet<FpComentario>();
            FpProyectos = new HashSet<FpProyecto>();
        }

        public int TarId { get; set; }
        public string TarNombre { get; set; } = null!;
        public string TarDescripcion { get; set; } = null!;
        public string TarCompletada { get; set; } = null!;
        public DateOnly TarFechaVencimiento { get; set; }
        public int TarAsignacion { get; set; }

        public virtual FpUsuario TarAsignacionNavigation { get; set; } = null!;
        public virtual ICollection<FpComentario> FpComentarios { get; set; }
        public virtual ICollection<FpProyecto> FpProyectos { get; set; }
    }
}
