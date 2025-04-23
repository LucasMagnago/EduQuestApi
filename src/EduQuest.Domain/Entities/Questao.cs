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
        public Disciplina Disciplina { get; set; } = null!;

        //// 2. Questao ---> Curso
        //public int CursoId { get; set; }
        //public Curso Curso { get; set; } = null!;

        // 3. Questao ---> Alternativa
        public int AlternativaCorretaId { get; set; }
        [ForeignKey("AlternativaCorretaId")]
        public Alternativa AlternativaCorreta { get; set; } = null!;

        // 4. Questao ---> Usuario
        public int UsuarioCriacaoId { get; set; }
        public Usuario UsuarioCriacao { get; set; } = null!;

        // 5. Questao ---> Alternativas
        [JsonIgnore]
        public virtual ICollection<Alternativa> Alternativas { get; set; } = new List<Alternativa>();

        // 5. BatalhaParticipante ---> BatalhaRespostaParticipante <--- Questao
        [JsonIgnore]
        public virtual ICollection<BatalhaRespostaParticipante> BatalhaRespostaParticipantes { get; set; } = new HashSet<BatalhaRespostaParticipante>();

        // 6. Questao ---> AtividadeQuestao <-- Atividade
        [JsonIgnore]
        public virtual ICollection<AtividadeQuestao> AtividadeQuestoes { get; set; } = new HashSet<AtividadeQuestao>();
    }
}
