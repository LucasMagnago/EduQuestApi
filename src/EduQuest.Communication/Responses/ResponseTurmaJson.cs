namespace EduQuest.Communication.Responses
{
    public class ResponseTurmaJson
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int Turno { get; set; }
        public bool Ativo { get; set; }
        public int NivelEscolar { get; set; }
        public int Ano { get; set; }
        public int EscolaId { get; set; }
    }
}
