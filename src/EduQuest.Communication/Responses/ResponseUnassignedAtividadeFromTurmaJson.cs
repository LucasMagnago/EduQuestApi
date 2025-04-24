namespace EduQuest.Communication.Responses
{
    public class ResponseUnassignedAtividadeFromTurmaJson
    {
        public DateTime DataAtribuicao { get; set; }
        public DateTime DataEntrega { get; set; }
        public int AtividadeId { get; set; }
        public int TurmaId { get; set; }
        public int DisciplinaId { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
