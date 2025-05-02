namespace EduQuest.Communication.Responses
{
    public class ResponseRankingTurmaJson
    {
        public int TurmaId { get; set; }
        public string DescricaoTurma { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public double Valor { get; set; }
        public int Posicao { get; set; }
    }
}
