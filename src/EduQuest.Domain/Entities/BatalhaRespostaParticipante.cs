using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduQuest.Domain.Entities
{
    public class BatalhaRespostaParticipante
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string RespostaDada { get; set; } = string.Empty;
        public bool Acertou { get; set; }
        public DateTime DataResposta { get; set; }

        // 1. BatalhaParticipante -> BatalhaRespostaParticipante <- Questao
        public int BatalhaParticipanteId { get; set; }
        [ForeignKey("BatalhaParticipanteId")]
        public virtual BatalhaParticipante BatalhaParticipante { get; set; } = null!;

        public int QuestaoId { get; set; }
        [ForeignKey("QuestaoId")]
        public virtual Questao Questao { get; set; } = null!;
    }
}
