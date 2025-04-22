namespace EduQuest.Communication.Responses
{
    public class ResponseCursoJson
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int ProximoCursoId { get; set; }
    }
}
