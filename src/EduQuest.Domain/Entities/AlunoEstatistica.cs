using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class AlunoEstatistica
    {
        [Key]
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; } = null!;
        public int TotalParticipacoes { get; set; }
        public int TotalVitorias { get; set; }
        public int AtividadesConcluidas { get; set; }
        public double MediaNotas { get; set; }
        public int TotalNotas { get; set; } // Para cálculo incremental da média

        public DateTime UltimaAtualizacao { get; set; }
    }
}
