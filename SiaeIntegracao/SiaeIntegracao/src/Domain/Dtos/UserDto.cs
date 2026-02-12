using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace SiaeIntegracao.src.Domain.Dtos
{
    public class UserDto
    {
        public int? Id { get; set; }
        [Required(ErrorMessage ="Campo nome é obrigatório.")]
        public string Name { get; set; } = string.Empty;
        public string? Lastname { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de email válido.")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        public string Password { get; set; } = string.Empty;
        public string? Role { get; set; } = string.Empty;
    }
}
