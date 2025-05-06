using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class EscolaEstatistica
    {
        [Key]
        public int EscolaId { get; set; }
        public Escola Escola { get; set; } = null!;

        public int TotalParticipacoes { get; set; }
        public int TotalVitorias { get; set; }
        public int AtividadesConcluidas { get; set; }
        public double MediaNotas { get; set; }
        public int TotalNotas { get; set; }

        public DateTime UltimaAtualizacao { get; set; }
    }
}
