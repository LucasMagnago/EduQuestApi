namespace EduQuest.Communication.Responses
{
    public class ResponseAlternativaJson
    {
        public int Id { get; set; }
        public string Texto { get; set; } = string.Empty;
        public int Ordem { get; set; }
        public int QuestaoId { get; set; }
    }
}
