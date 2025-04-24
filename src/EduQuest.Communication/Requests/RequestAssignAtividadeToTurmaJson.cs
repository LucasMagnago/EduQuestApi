namespace EduQuest.Communication.Requests
{
    public class RequestAssignAtividadeToTurmaJson
    {
        public DateTime DataAtribuicao { get; set; }
        public DateTime DataEntrega { get; set; }
        public int AtividadeId { get; set; }
        public int TurmaId { get; set; }
        public int DisciplinaId { get; set; }
    }
}
