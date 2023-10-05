using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.DTOs
{
    public class ComentarioDTO
    {
        public int ComId { get; set; }

        [Required(ErrorMessage = "El contenido del comentario es obligatorio.")]
        [StringLength(500, ErrorMessage = "El contenido del comentario no debe exceder los 500 caracteres.")]
        public string ComContenido { get; set; }
        [Required(ErrorMessage = "La fecha de creación del comentario es obligatoria.")]

        public DateOnly ComFechaCreacion { get; set; }
        public int ComTareaId { get; set; }

        public virtual FpTarea ComTarea { get; set; } = null!;
    }

    public class ComentarioUpdateDTO
    {
        public int ComId { get; set; }

        [StringLength(500, ErrorMessage = "El contenido del comentario no debe exceder los 500 caracteres.")]
        public string? ComContenido { get; set; }

        public DateOnly? ComFechaCreacion { get; set; }

        public virtual FpTarea ComTarea { get; set; } = null!;
    }
}
