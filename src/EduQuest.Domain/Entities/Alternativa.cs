using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class Alternativa
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int Ordem { get; set; }
        public Questao Questao { get; set; } = default!;
    }
}
