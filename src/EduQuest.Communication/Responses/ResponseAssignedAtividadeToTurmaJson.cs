namespace EduQuest.Communication.Responses
{
    public class ResponseAssignedAtividadeToTurmaJson
    {
        public int Id { get; set; }
        public DateTime DataAtribuicao { get; set; }
        public DateTime DataEntrega { get; set; }
        public int AtividadeId { get; set; }
        public int TurmaId { get; set; }
        public int DisciplinaId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
