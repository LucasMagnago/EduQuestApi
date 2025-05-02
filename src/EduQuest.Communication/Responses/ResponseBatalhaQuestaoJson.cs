namespace EduQuest.Communication.Responses
{
    public class ResponseBatalhaQuestaoJson
    {
        public int Id { get; set; }
        public int Ordem { get; set; }
        public int BatalhaId { get; set; }
        public ResponseShortQuestaoJson Questao { get; set; } = null!;
    }
}
