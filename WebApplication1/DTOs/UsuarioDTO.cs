using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
        [MaxLength(50, ErrorMessage = "El nombre debe tener máximo 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre solo puede contener letras.")]
        public string UsuNombre { get; set; }
        public string UsuCorreo { get; set; }

        [Required(ErrorMessage = "El password es obligatorio.")]
        /*[MinLength(8, ErrorMessage = "El password debe tener al menos 8 caracteres.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "El password debe tener al menos una mayúscula, una minúscula, un número y un caracter especial.")]*/
        public string UsuContrasena { get; set; }
    }

    public class UsuariosUpdateDTO
    {
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
        [MaxLength(50, ErrorMessage = "El nombre debe tener máximo 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre solo puede contener letras.")]
        public string? NombreUsuario { get; set; }


        /*[MinLength(8, ErrorMessage = "El password debe tener al menos 8 caracteres.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "El password debe tener al menos una mayúscula, una minúscula, un número y un caracter especial.")]*/
        public string? Contrasena { get; set; }
    }
}
