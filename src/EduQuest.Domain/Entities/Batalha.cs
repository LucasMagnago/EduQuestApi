using EduQuest.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class Batalha
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int TempoLimiteSegundos { get; set; }
        public StatusBatalha Status { get; set; }

        // 1. Batalha --> Atividade
        public Atividade Atividade { get; set; } = null!;
        public int AtividadeId { get; set; }

        // 2. Batalha --> BatalhaParticipante <-- Aluno
        public virtual ICollection<BatalhaParticipante> BatalhaParticipantes { get; set; } = new HashSet<BatalhaParticipante>();
    }
}
