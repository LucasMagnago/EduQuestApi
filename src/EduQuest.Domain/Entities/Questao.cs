using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EduQuest.Domain.Entities
{
    public class Questao
    {
        [Key]
        public int Id { get; set; }
        public string Enunciado { get; set; } = string.Empty;
        public string Resposta { get; set; } = string.Empty;
        public int NivelEscola { get; set; }

        // 1. Questao ---> Disciplina
        public int DisciplinaId { get; set; }
        [JsonIgnore]
        public virtual Disciplina Disciplina { get; set; } = null!;

        //// 2. Questao ---> Curso
        //public int CursoId { get; set; }
        //public Curso Curso { get; set; } = null!;

        // 3. Questao ---> Alternativa
        public int AlternativaCorretaId { get; set; }
        [ForeignKey("AlternativaCorretaId")]
        public virtual Alternativa AlternativaCorreta { get; set; } = null!;

        // 4. Questao ---> Usuario
        public int UsuarioCriacaoId { get; set; }
        [JsonIgnore]
        public virtual Usuario UsuarioCriacao { get; set; } = null!;

        // 5. Questao ---> Alternativas
        public virtual ICollection<Alternativa> Alternativas { get; set; } = new List<Alternativa>();

        // 7. Questao ---> BatalhaQuestao <--- Batalha
        [JsonIgnore]
        public virtual ICollection<BatalhaQuestao> BatalhaQuestoes { get; set; } = new HashSet<BatalhaQuestao>();

        [JsonIgnore]
        public virtual ICollection<BatalhaResposta> BatalhaRespostas { get; set; } = new HashSet<BatalhaResposta>();

        // 6. Questao ---> AtividadeQuestao <-- Atividade
        [JsonIgnore]
        public virtual ICollection<AtividadeQuestao> AtividadeQuestoes { get; set; } = new HashSet<AtividadeQuestao>();

        [JsonIgnore]
        public virtual ICollection<AtividadeResposta> AtividadeRespostas { get; set; } = new HashSet<AtividadeResposta>();

        public bool IsCorrectAnswer(int alternativaId)
        {
            return this.AlternativaCorretaId == alternativaId;
        }
    }
}
