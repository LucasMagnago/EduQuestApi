using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class AtividadeQuestao
    {
        [Key]
        public int Id { get; set; }
        public int Ordem { get; set; }

        public int AtividadeId { get; set; }
        public virtual Atividade Atividade { get; set; } = null!;

        public int QuestaoId { get; set; }
        public Questao Questao { get; set; } = null!;
    }
}
