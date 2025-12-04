using System.ComponentModel.DataAnnotations;

namespace PetsDog.Models
{
    public class Agendamento
    {
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public int PetId { get; set; }

        [Required]
        public DateTime DataHora { get; set; }

        public string? Status { get; set; }
    }
}
