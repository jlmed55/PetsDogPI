namespace PetsDog.Models
{
    public class Cliente
    {
        public int Idcliente { get; set; }

        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? Senha { get; set; }

        public string? Telefone { get; set; }

        public  DateTime Datacadastro {  get; set; }
    }
}
