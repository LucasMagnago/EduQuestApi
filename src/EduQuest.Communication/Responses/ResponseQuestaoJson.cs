namespace EduQuest.Communication.Responses
{
    public class ResponseQuestaoJson
    {
        public int Id { get; set; }
        public string Enunciado { get; set; } = string.Empty;
        public string Resposta { get; set; } = string.Empty;
        public int NivelEscola { get; set; }
        public int DisciplinaId { get; set; }
        public ResponseShortAlternativaJson? AlternativaCorreta { get; set; }
        public ResponseShortUsuarioJson UsuarioCriacao { get; set; } = null!;

        public IEnumerable<ResponseShortAlternativaJson> Alternativas { get; set; } = new List<ResponseShortAlternativaJson>();
    }
}
