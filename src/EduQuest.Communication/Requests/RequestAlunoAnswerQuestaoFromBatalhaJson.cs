namespace EduQuest.Communication.Requests
{
    public class RequestAlunoAnswerQuestaoFromBatalhaJson
    {
        public int AlunoId { get; set; }
        public int BatalhaId { get; set; }
        public int QuestaoId { get; set; }
        public int AlternativaEscolhaId { get; set; }
    }
}
