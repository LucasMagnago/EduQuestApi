namespace EduQuest.Communication.Requests
{
    public class RequestRegisterQuestaoJson
    {
        public string Enunciado { get; set; } = string.Empty;
        public string Resposta { get; set; } = string.Empty;
        public int NivelEscola { get; set; }
        public int DisciplinaId { get; set; }
        public int UsuarioCriacaoId { get; set; }

    }
}
