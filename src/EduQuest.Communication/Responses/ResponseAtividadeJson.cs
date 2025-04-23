namespace EduQuest.Communication.Responses
{
    public class ResponseAtividadeJson
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int Valor { get; set; }
        public int TempoLimiteSegundos { get; set; }
        public int XpRecompensa { get; set; } = 10;
        public int MoedasRecompensa { get; set; } = 10;
        public DateTime DataCriacao { get; set; }
        public int ProfessorId { get; set; }
    }
}
