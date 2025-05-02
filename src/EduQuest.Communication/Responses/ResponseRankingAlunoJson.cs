namespace EduQuest.Communication.Responses
{
    public class ResponseRankingAlunoJson
    {
        public int AlunoId { get; set; }
        public string NomeAluno { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public double Valor { get; set; }
        public int Posicao { get; set; }
    }
}
