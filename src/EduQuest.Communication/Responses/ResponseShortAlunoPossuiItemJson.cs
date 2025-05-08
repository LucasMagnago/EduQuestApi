namespace EduQuest.Communication.Responses
{
    public class ResponseShortAlunoPossuiItemJson
    {
        public int Id { get; set; }
        public DateTime DataAquisicao { get; set; }
        public ResponseShortItemJson Item { get; set; } = null!;
    }
}
