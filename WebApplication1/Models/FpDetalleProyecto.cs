using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class FpDetalleProyecto
    {
        public int DproId { get; set; }
        public DateOnly DproFechaIntegracion { get; set; }
        public int DproProyecto { get; set; }
        public int DproUsuario { get; set; }

        public virtual FpProyecto DproProyectoNavigation { get; set; } = null!;
        public virtual FpUsuario DproUsuarioNavigation { get; set; } = null!;
    }
}
