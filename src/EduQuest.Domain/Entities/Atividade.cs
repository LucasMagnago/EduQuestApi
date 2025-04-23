using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EduQuest.Domain.Entities
{
    public class Atividade
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int Valor { get; set; }
        public int TempoLimiteSegundos { get; set; }
        public DateTime DataCriacao { get; set; }

        // 1. Atividade ---> TipoAtividade
        public int TipoAtividadeId { get; set; }
        public TipoAtividade TipoAtividade { get; set; } = null!;

        // 2. Atividade ---> Usuário
        public int ProfessorId { get; set; }
        public Usuario Professor { get; set; } = null!;

        // 3. Atividade ---> AtividadeQuestao <--- Questao 
        [JsonIgnore]
        public virtual ICollection<AtividadeQuestao> AtividadeQuestoes { get; set; } = new HashSet<AtividadeQuestao>();

        // 4. Atividade ---> AlunoRealizaAtividade <--- Aluno
        [JsonIgnore]
        public virtual ICollection<AlunoRealizaAtividade> AlunoRealizaAtividades { get; set; } = new HashSet<AlunoRealizaAtividade>();

        // 5. Atividade ---> AtividadeTurma <--- Turma
        [JsonIgnore]
        public virtual ICollection<AtividadeTurma> AtividadeTurmas { get; set; } = new HashSet<AtividadeTurma>();
    }
}
