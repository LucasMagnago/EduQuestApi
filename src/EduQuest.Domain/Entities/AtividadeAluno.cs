using EduQuest.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class AtividadeAluno
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int PontuacaoObtida { get; set; }
        public int XpGanho { get; set; }
        public int MoedasGanhas { get; set; }
        public string FeedbackProfessor { get; set; } = string.Empty;
        public StatusAtividade Status { get; set; } = StatusAtividade.Pendente;

        // 1. Aluno ---> AtividadeAlunos <--- Atividade
        public int AlunoId { get; set; }
        public virtual Aluno Aluno { get; set; } = default!;
        public int AtividadeId { get; set; }
        public virtual Atividade Atividade { get; set; } = default!;

        // 2. AtividadeAluno ---> RespostaAtividade
        public virtual ICollection<AtividadeResposta> AtividadeRespostas { get; set; } = new HashSet<AtividadeResposta>();
    }
}
