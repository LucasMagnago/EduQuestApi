namespace EduQuest.Communication.DTOs
{
    internal class AlunoRankingDTO
    {
        public class AlunoRankingDto
        {
            public int AlunoId { get; set; }
            public string NomeAluno { get; set; } = string.Empty;
            public string Descricao { get; set; } = string.Empty; // Descrição da métrica (Ex: "Nº Atividades", "Média", "Nº Batalhas", etc.)
            public double Valor { get; set; } // Métrica (Nº Atividades, Média, Nº Batalhas, etc.)
            public int Posicao { get; set; } // Posição no ranking
        }
    }
}