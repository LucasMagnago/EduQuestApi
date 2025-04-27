using EduQuest.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EduQuest.Domain.Entities
{
    public class Batalha
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int TempoLimiteSegundos { get; set; }
        public StatusBatalha Status { get; set; }

        // Relacionamento com Alunos (2 alunos por batalha)
        public int AlunoAId { get; set; }
        public virtual Aluno AlunoA { get; set; } = null!;
        public int AlunoBId { get; set; }
        public virtual Aluno AlunoB { get; set; } = null!;

        // Relacionamento com BatalhaQuestoes (questões respondidas na batalha)
        [JsonIgnore]
        public virtual ICollection<BatalhaQuestao> BatalhaQuestoes { get; set; } = new HashSet<BatalhaQuestao>();

        // Relacionamento com BatalhaRespostas (respostas fornecidas pelos alunos)
        [JsonIgnore]
        public virtual ICollection<BatalhaResposta> BatalhaRespostas { get; set; } = new HashSet<BatalhaResposta>();
    }
}
