using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class BatalhaQuestao
    {
        [Key]
        public int Id { get; set; }

        public int BatalhaId { get; set; }
        public virtual Batalha Batalha { get; set; } = null!;
        public int QuestaoId { get; set; }
        public virtual Questao Questao { get; set; } = null!;
    }
}
