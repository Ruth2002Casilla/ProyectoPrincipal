using System.ComponentModel.DataAnnotations;

namespace MainProject.Models
{
    public class Tickets
    {
        [Key]

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public int TicketId { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string Fecha { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public int SistemaId { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public int PrioridadId { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string SolicitadoPor { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string Asunto { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string Descripcion { get; set; }
    }
}
