using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class Conquista
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string IconeUrl { get; set; } = string.Empty;
        public string CriterioTipo { get; set; } = string.Empty;
        public string CriterioValor { get; set; } = string.Empty;
    }
}
