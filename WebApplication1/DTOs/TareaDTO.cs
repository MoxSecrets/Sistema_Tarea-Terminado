using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.DTOs
{
    public class TareaDTO
    {
        public int TarId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
        [MaxLength(50, ErrorMessage = "El nombre debe tener maximo 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre solo puede contener letras.")]
        public string TarNombre { get; set; }

        [MaxLength(50, ErrorMessage = "La descripcion debe tener maximo 50 caracteres.")]
        public string TarDescripcion { get; set; }

        [MaxLength(10, ErrorMessage = "El Estado tiene que decir: 'Realizada', 'En Proceso' ó 'Finalizada'.")]
        public string TarCompletada { get; set; }

        public int TarAsignacion { get; set; }
    }

    public class TareasUpdateDTO
    {
        public int TarId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
        [MaxLength(50, ErrorMessage = "El nombre debe tener máximo 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre solo puede contener letras.")]
        public string? TarNombre { get; set; }

        [MaxLength(50, ErrorMessage = "La descripción debe tener máximo 50 caracteres.")]
        public string? TarDescripcion { get; set; }

        public string? TarCompletada { get; set; }

        [Required(ErrorMessage = "La fecha de vencimiento es obligatoria.")]
        public DateTime? TarFechaVencimiento { get; set; }

        public int? TarAsignacion { get; set; }

        public virtual FpUsuario TarAsignacionNavigation { get; set; } = null!;
    }
}
