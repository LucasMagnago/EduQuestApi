namespace EduQuest.Communication.Requests
{
    public class RequestRegisterAtividadeJson
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int Valor { get; set; }
        public int TempoLimiteSegundos { get; set; }
        public int ProfessorId { get; set; }
    }
}
