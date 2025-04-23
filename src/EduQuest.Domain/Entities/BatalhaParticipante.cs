using EduQuest.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EduQuest.Domain.Entities
{
    public class BatalhaParticipante
    {
        [Key]
        public int Id { get; set; }
        public int Pontuacao { get; set; }
        public int TempoTotalSegundos { get; set; }
        public int XpRecebido { get; set; }
        public int MoedaRecebidas { get; set; }
        public StatusParticipanteBatalha Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        // 1. Aluno -> BatalhaParticipante <-Batalha
        public int BatalhaId { get; set; }
        [ForeignKey("BatalhaId")]
        public virtual Batalha Batalha { get; set; } = null!;

        public int AlunoId { get; set; }
        [ForeignKey("AlunoId")]
        public virtual Aluno Aluno { get; set; } = null!;

        // 2. BatalhaParticipante -> BatalhaRespostaParticipante <- Questao
        [JsonIgnore]
        public virtual ICollection<BatalhaRespostaParticipante> BatalhaRespostaParticipantes { get; set; } = new HashSet<BatalhaRespostaParticipante>();


    }
}
