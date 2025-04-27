namespace EduQuest.Communication.Requests
{
    public class RequestAlunoAnswerQuestaoFromAtividadeJson
    {
        public int AlunoId { get; set; }
        public int AtividadeId { get; set; }
        public int QuestaoId { get; set; }
        public int AlternativaEscolhaId { get; set; }
    }
}
