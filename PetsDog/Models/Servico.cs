using System.ComponentModel.DataAnnotations.Schema;

namespace PetsDog.Models
{
    public class Servico(int idServico = 0, string? nome = null, int duracaoMin = 0, decimal preco = 0m)
    {
        public int Idservico { get; set; } = idServico;

        [Column("nome")]
        public string? Nome { get; set; } = nome;

        [Column("duracao_min")]
        public int DuracaoMin { get; set; } = duracaoMin;

        [Column("preco")]
        public decimal Preco { get; set; } = preco;

        public ICollection<Agendamento>? Agendamentos { get; set; }
    }
}
