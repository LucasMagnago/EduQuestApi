namespace EduQuest.Communication.Requests
{
    public class RequestRegisterTurmaJson
    {
        public string Descricao { get; set; } = string.Empty;
        public int Turno { get; set; }
        public int NivelEscolar { get; set; }
        public int Ano { get; set; }
        public int CursoId { get; set; }
        public int PeriodoLetivoId { get; set; }
        public int EscolaId { get; set; }
    }
}
