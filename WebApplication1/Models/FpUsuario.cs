using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class FpUsuario
    {
        public FpUsuario()
        {
            FpDetalleProyectos = new HashSet<FpDetalleProyecto>();
            FpTareas = new HashSet<FpTarea>();
        }

        public int UsuId { get; set; }
        public string UsuNombre { get; set; } = null!;
        public string UsuCorreo { get; set; } = null!;
        public string UsuContrasena { get; set; } = null!;

        public virtual ICollection<FpDetalleProyecto> FpDetalleProyectos { get; set; }
        public virtual ICollection<FpTarea> FpTareas { get; set; }
    }
}
