using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.DTOs
{
    public class DetalleProyectoDTO
    {
        public int DproId { get; set; }

        [Required(ErrorMessage = "La fecha de integracion es obligatoria.")]
        public DateOnly DproFechaIntegracion { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El valor de ProyectoId debe ser mayor o igual a 1.")]
        public int DproProyecto { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El valor de UsuarioId debe ser mayor o igual a 1.")]
        public int DproUsuario { get; set; }

        public virtual FpProyecto DproProyectoNavigation { get; set; } = null!;
        public virtual FpUsuario DproUsuarioNavigation { get; set; } = null!;

    }

    public class DetalleProyectoUpdateDTO
    {
        public int DproId { get; set; }

        [Required(ErrorMessage = "La fecha de integracion es obligatoria.")]
        public DateOnly? DproFechaIntegracion { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El valor de ProyectoId debe ser mayor o igual a 1.")]
        public int? DproProyecto { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El valor de UsuarioId debe ser mayor o igual a 1.")]
        public int? DproUsuario { get; set; }

        public virtual FpProyecto DproProyectoNavigation { get; set; } = null!;
        public virtual FpUsuario DproUsuarioNavigation { get; set; } = null!;
    }
}
