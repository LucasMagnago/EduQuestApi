namespace EduQuest.Communication.Responses
{
    public class ResponseTurmaJson
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int Turno { get; set; }
        public int CursoId { get; set; }
        public int PeriodoLetivoId { get; set; }
        public int EscolaId { get; set; }
    }
}
