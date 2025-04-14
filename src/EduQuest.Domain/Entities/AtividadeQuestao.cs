namespace EduQuest.Domain.Entities
{
    public class AtividadeQuestao
    {
        public int Id { get; set; }
        public int Ordem { get; set; }
        public int AtividadeId { get; set; }
        public int QuestaoId { get; set; }
    }
}
