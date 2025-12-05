using Microsoft.AspNetCore.Mvc.Rendering;

namespace PetsDog.Models.ViewModels
{
    public class AgendamentoFormViewModel
    {
        public Agendamento Agendamento { get; set; } = new();
        public SelectList Animais { get; set; } = default!;
        public SelectList Servicos { get; set; } = default!;
        public SelectList Profissionais { get; set; } = default!;
    }
}
