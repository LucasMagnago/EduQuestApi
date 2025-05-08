namespace EduQuest.Communication.Responses
{
    public class ResponseShortItemJson
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string ImagemBase64 { get; set; } = string.Empty;
    }
}
