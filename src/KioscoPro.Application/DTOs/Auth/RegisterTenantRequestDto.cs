using System.ComponentModel.DataAnnotations;

namespace KioscoPro.Application.DTOs.Auth
{
    public class RegisterTenantRequestDto
    {
        // Datos de la empresa
        [Required(ErrorMessage = "El nombre de la empresa es obligatorio.")]
        [StringLength(100, MinimumLength = 2,
            ErrorMessage = "El nombre de la empresa debe tener entre 2 y 100 caracteres.")]
        public string CompanyName { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "El correo electrónico de la empresa no es válido.")]
        public string? CompanyEmail { get; set; }

        [Phone(ErrorMessage = "El número de teléfono de la empresa no es válido.")]
        public string? CompanyPhone { get; set; }

        [Required(ErrorMessage = "La dirección de la empresa es obligatoria.")]
        public string CompanyAddress { get; set; } = string.Empty;

        // Datos del usuario
        [Required(ErrorMessage = "El nombre completo es obligatorio.")]
        [StringLength(150, MinimumLength = 4,
            ErrorMessage = "El nombre completo debe tener al menos 4 caracteres.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string UserEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
        [Phone(ErrorMessage = "El número de teléfono no es válido.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(100, MinimumLength = 8,
            ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
        [RegularExpression(
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$",
            ErrorMessage = "La contraseña debe contener al menos una mayúscula, una minúscula y un número."
        )]
        public string PasswordHash { get; set; } = string.Empty;

        [Compare("PasswordHash", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe seleccionar un plan.")]
        public string SelectedPlan { get; set; } = "Free";
    }
}
