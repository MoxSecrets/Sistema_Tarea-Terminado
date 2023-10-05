using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.DTOs
{
    public class ProyectoDTO
    {
        public int ProId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
        [MaxLength(50, ErrorMessage = "El nombre debe tener maximo 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre solo puede contener letras.")]
        public string ProNombre { get; set; }
        
        
        [MaxLength(50, ErrorMessage = "la descripcion debe tener un maximo de 50 caracteres.")]
        public string ProDescripcion { get; set; }
        
        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        public DateOnly ProFechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha de finalizacion es obligatoria.")]
        public DateOnly ProFechaFinalizacion { get; set; }

        public int ProTareaId { get; set; }

        public virtual FpTarea ProTarea { get; set; } = null!;
        public ICollection<FpDetalleProyecto> FpDetalleProyectos { get; set; }
        

    }

    public class ProyectoUpdateDTO
    {
        public int ProId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
        [MaxLength(50, ErrorMessage = "El nombre debe tener máximo 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre solo puede contener letras.")]
        public string? ProNombre { get; set; }

        [MaxLength(50, ErrorMessage = "La descripción debe tener máximo 50 caracteres.")]
        public string? ProDescripcion { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        public DateOnly? ProFechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha de finalización es obligatoria.")]
        public DateOnly? ProFechaFinalizacion { get; set; }

        public int? ProTareaId { get; set; }

        public virtual FpTarea ProTarea { get; set; } = null!;
        public ICollection<FpDetalleProyecto> FpDetalleProyectos { get; set; }
        
    }
}
