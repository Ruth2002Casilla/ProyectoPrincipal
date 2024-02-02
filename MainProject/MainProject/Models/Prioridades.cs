using System.ComponentModel.DataAnnotations;

namespace MainProject.Models
{
    public class Prioridades
    {
        [Key]

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public int PrioridadId { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string Descripcion { get; set; }

        [Range(1, 31, ErrorMessage = "Valores validos del 1 al 31")]
        public int DiasCompromiso { get; set; }
    }
}
