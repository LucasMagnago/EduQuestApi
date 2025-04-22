namespace EduQuest.Communication.Responses
{
    public class ResponseRegisteredCursoJson
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public bool ativo { get; set; }
        public int? ProximoCursoId { get; set; }
    }
}
