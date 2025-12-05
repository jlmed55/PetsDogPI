using System.ComponentModel.DataAnnotations.Schema;

namespace PetsDog.Models
{
    public class Profissional(int idProfissional = 0, string? nome = null, string? especialidade = null, string? disponibilidadeInicio = null, string? diponibilidadeFim = null)
    {
        [Column("id_profissional")]
        public int IdProfissional { get; set; } = idProfissional;

        [Column("nome")]
        public string? Nome { get; set; } = nome;

        [Column("especialidade")]
        public string? Especialidade { get; set; } = especialidade;

        public string? DisponibilidadeInicio { get; set; } = disponibilidadeInicio;

        [Column("DiponibilidadeFim")]
        public string? DiponibilidadeFim { get; set; } = diponibilidadeFim;

        public ICollection<Agendamento>? Agendamentos { get; set; }
    }
}
