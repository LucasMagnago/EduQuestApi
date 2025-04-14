namespace EduQuest.Domain.Entities
{
    public class Aluno : Usuario
    {
        // Não define uma nova chave primária, usa a Id herdada de Usuario.

        public int XpAtual { get; set; }
        public int Nivel { get; set; }
        public int SaldoMoedas { get; set; }
        public int StreakDiasConsecutivos { get; set; }
        public DateTime DataUltimoAcessoStreak { get; set; }

        // Apenas a navegação para as Matrículas (que contêm o payload)
        public virtual ICollection<Matricula> Matriculas { get; set; } = new HashSet<Matricula>();

        // Apenas a navegação para AlunoRealizaAtividade (que contêm o payload)
        public virtual ICollection<AlunoRealizaAtividade> AlunoRealizaAtividades { get; set; } = new HashSet<AlunoRealizaAtividade>();

        // Navegação para as participações do aluno em batalhas
        public virtual ICollection<BatalhaParticipante> ParticipacoesEmBatalhas { get; set; } = new HashSet<BatalhaParticipante>();
    }
}
