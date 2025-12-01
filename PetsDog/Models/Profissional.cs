namespace PetsDog.Models
{
    public class Profissional
    {
        public int id_profissional { get; set; }

        public string? nome { get; set; }

        public string? especialidade {  get; set; }

        public string? DisponibilidadeInicio { get; set; }

        public string? DiponibilidadeFim {  get; set; }
        public ICollection<Agendamento>? Agendamentos { get; set; }
    }
}
