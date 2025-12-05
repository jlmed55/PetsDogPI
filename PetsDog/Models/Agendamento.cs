using System.ComponentModel.DataAnnotations;

namespace PetsDog.Models
{
    public class Agendamento
    {
        public int Id { get; set; }

        [Required]
        public int AnimalId { get; set; }

        [Required]
        public int ServicoId { get; set; }

        [Required]
        public int ProfissionalId { get; set; }

        [Required]
        public DateTime DataHora { get; set; }

        public string? Status { get; set; }

        public Animal? Animal { get; set; }
        public Servico? Servico { get; set; }
        public Profissional? Profissional { get; set; }
    }
}
