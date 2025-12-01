using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace PetsDog.Models
{
    public class Agendamento
    {

        public  int id_agendamento {  get; set; }

        public DateTime  data_hora { get; set; }

        public string? status { get; set; }

        public  int id_animal { get; set; }

        public int id_servico { get; set; }

        public int id_profissional { get; set; }

        public Animal? Animal { get; set; }
        public Servico? Servico { get; set; }
        public Profissional? Profissional { get; set; }


    }
}
