namespace EduQuest.Communication.Requests
{
    public class RequestRegisterCursoJson
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public int? ProximoCursoId { get; set; }
    }
}
