using System.ComponentModel.DataAnnotations;

namespace PetsDog.Models
{
    public class Animal
    {
        public int id_animal { get; set; }

        public string? Nome { get; set; }

        public string? Especie { get; set; }

        public string? Porte {  get; set; }

        public int Idade { get; set; }

        public  int Id_cliente {  get; set; }
        public Cliente? Cliente { get; set; }
        public ICollection<Agendamento>? Agendamentos { get; set; }
    }
}
