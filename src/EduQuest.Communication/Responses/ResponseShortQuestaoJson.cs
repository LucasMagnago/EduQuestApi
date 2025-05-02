namespace EduQuest.Communication.Responses
{
    public class ResponseShortQuestaoJson
    {
        public int Id { get; set; }
        public string Enunciado { get; set; } = string.Empty;
        public string Resposta { get; set; } = string.Empty;
        public int AlternativaCorretaId { get; set; }

        public IEnumerable<ResponseShortAlternativaJson> Alternativas { get; set; } = new List<ResponseShortAlternativaJson>();
    }
}
