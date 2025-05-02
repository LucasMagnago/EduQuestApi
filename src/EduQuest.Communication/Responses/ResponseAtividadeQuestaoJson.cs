namespace EduQuest.Communication.Responses
{
    public class ResponseAtividadeQuestaoJson
    {
        public int Id { get; set; }
        public ResponseShortQuestaoJson Questao { get; set; } = null!;
        public int AtividadeId { get; set; }
    }
}
