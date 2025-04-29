using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EduQuest.Domain.Entities
{
    public class BatalhaResposta
    {
        [Key]
        public int Id { get; set; }
        public bool Acertou { get; set; }
        public DateTime DataResposta { get; set; }

        public int BatalhaId { get; set; }
        [JsonIgnore]
        public virtual Batalha Batalha { get; set; } = null!;

        public int QuestaoId { get; set; }
        [JsonIgnore]
        public virtual Questao Questao { get; set; } = null!;

        public int AlternativaEscolhaId { get; set; }
        [JsonIgnore]
        public virtual Alternativa AlternativaEscolha { get; set; } = null!;

        public int AlunoId { get; set; }
        [JsonIgnore]
        public Aluno Aluno { get; set; } = null!;
    }
}
