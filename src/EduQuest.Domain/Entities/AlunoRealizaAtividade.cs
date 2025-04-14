namespace EduQuest.Domain.Entities
{
    public class AlunoRealizaAtividade
    {
        public int AlunoId { get; set; }
        public virtual Aluno Aluno { get; set; } = default!;
        public int AtividadeId { get; set; }
        public virtual Atividade Atividade { get; set; } = default!;

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int PontuacaoObtida { get; set; }
        public int XpGanho { get; set; }
        public int MoedasGanhas { get; set; }
        public string FeedbackProfessor { get; set; } = string.Empty;
    }
}
