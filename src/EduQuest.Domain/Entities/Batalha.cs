using EduQuest.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class Batalha
    {
        [Key]
        public int Id { get; set; }
        public Atividade Atividade { get; set; } = default!;
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int TempoLimiteSegundos { get; set; }
        public StatusBatalha Status { get; set; }
    }
}
