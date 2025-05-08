namespace EduQuest.Communication.Responses
{
    public class ResponseAlunoConquistaJson
    {
        public int Id { get; set; }
        public DateTime DataObtencao { get; set; }
        public ResponseShortConquistaJson Conquista { get; set; } = default!;
    }
}
