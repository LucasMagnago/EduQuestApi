using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class EscolaEstatistica
    {
        [Key]
        public int EscolaId { get; set; }
        public Escola Escola { get; set; } = null!;

        public int TotalParticipacoesInBatalhas { get; set; }
        public int TotalVitoriasInBatalhas { get; set; }
        public int AtividadesConcluidas { get; set; }
        public double MediaNotasNormalizadas { get; set; }
        public int QuantidadeNotasValidas { get; set; }

        public DateTime UltimaAtualizacao { get; set; }
    }
}
