using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class AlunoEstatistica
    {
        [Key]
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; } = null!;
        public int TotalParticipacoesInBatalhas { get; set; } = 0;
        public int TotalVitoriasInBatalhas { get; set; } = 0;
        public int AtividadesConcluidas { get; set; } = 0;
        public double MediaNotasNormalizadas { get; set; } = 0.0;
        public int QuantidadeNotasValidas { get; set; } = 0; // Para cálculo incremental da média
        public DateTime UltimaAtualizacao { get; set; }
    }
}
