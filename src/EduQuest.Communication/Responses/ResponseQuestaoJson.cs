namespace EduQuest.Communication.Responses
{
    public class ResponseQuestaoJson
    {
        public int Id { get; set; }
        public string Enunciado { get; set; } = string.Empty;
        public string Resposta { get; set; } = string.Empty;
        public int NivelEscola { get; set; }
        public int DisciplinaId { get; set; }
        public int? AlternativaCorretaId { get; set; }
        public int UsuarioCriacaoId { get; set; }

        public IEnumerable<ResponseAlternativaJson> Alternativas { get; set; } = new List<ResponseAlternativaJson>();
    }
}
