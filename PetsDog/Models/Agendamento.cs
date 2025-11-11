using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace PetsDog.Models
{
    public class Agendamento
    {

        public  int IdAgendamento {  get; set; }

        public DateTime  data_hora { get; set; }

        public string? status { get; set; }

        public int Idcliente { get; set; }

        public  int Idanimal { get; set; }

        public int Idservico { get; set; }

        public int Idprofissional { get; set; }
    }
}
