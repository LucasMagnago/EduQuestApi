namespace EduQuest.Communication.Requests
{
    public class RequestRegisterAlternativaJson
    {
        public string Texto { get; set; } = string.Empty;
        public int Ordem { get; set; }
        public int QuestaoId { get; set; }
    }
}
