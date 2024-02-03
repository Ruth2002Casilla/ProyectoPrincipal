using System.ComponentModel.DataAnnotations;

namespace MainProject.Models
{
    public class Clientes
    {
        [Key]

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string NombreCliente { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string TelefonoCliente { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string CelularCliente { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string RNCCliente { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string EmailCliente { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string DireccionCliente { get; set; }
    }
}
