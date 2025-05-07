namespace EduQuest.Communication.DTOs
{
    public class EscolaRankingDTO
    {
        public int EscolaId { get; set; }
        public string EscolaNome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty; // Descrição da métrica (Ex: "Nº Atividades", "Média", "Nº Batalhas", etc.)
        public double Valor { get; set; } // Métrica (Nº Atividades, Média, Nº Batalhas, etc.)
        public int Posicao { get; set; } // Posição no ranking
    }
}